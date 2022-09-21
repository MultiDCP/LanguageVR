//========= Copyright 2019, HTC Corporation. All rights reserved. ===========
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace ViveSR
{
    namespace anipal
    {
        namespace Lip
        {
            public class SRanipal_AvatarLipSample_v2 : MonoBehaviourPunCallbacks, IPunObservable
            {
                [SerializeField] private List<LipShapeTable_v2> LipShapeTables;

                public bool NeededToGetData = true;
                public Dictionary<LipShape_v2, float> LipWeightings;
                public Dictionary<LipShape_v2, float> otherWeightings;
                public PhotonView pv;

                private void Start()
                {
                    // 입모양을 움직일 수 있다면 
                    if (!SRanipal_Lip_Framework.Instance.EnableLip)
                    {
                        enabled = false;
                        return;
                    }
                    SetLipShapeTables(LipShapeTables);
                    otherWeightings = new Dictionary<LipShape_v2, float>();
                    PhotonNetwork.SerializationRate = 60;
                }

                private void Update()
                {
                    if (SRanipal_Lip_Framework.Status != SRanipal_Lip_Framework.FrameworkStatus.WORKING) return;

                    if (pv.IsMine)
                    {
                        if (NeededToGetData)
                        {
                            SRanipal_Lip_v2.GetLipWeightings(out LipWeightings);
                            UpdateLipShapes(LipWeightings);
                        }
                    }
                    else
                    {
                        if (NeededToGetData)
                        {
                            UpdateLipShapes(otherWeightings);
                        }
                    }
                }

                public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
                {
                    if (stream.IsWriting)
                    {
                        List<float> values = new List<float>(LipWeightings.Values);
                        float[] valueArray = values.ToArray();
                        stream.SendNext(valueArray);
                        //Debug.LogWarning("Send Data");
                    }
                    else
                    {
                        float[] valueArray = new float[(int)LipShape_v2.Max];
                        valueArray = (float[])stream.ReceiveNext();
                        //Debug.LogWarning("Receive Data");
                        this.otherWeightings.Clear();
                        for (int i=0; i<valueArray.Length; i++)
                        {
                            this.otherWeightings.Add((LipShape_v2)i, valueArray[i]);
                            //Debug.LogWarning("LipShape_V2 : " + i + ", valueArray[i] = " + valueArray[i]);
                        }
                    }
                }

                private void UpdateOtherData()
                {

                }

                public void SetLipShapeTables(List<LipShapeTable_v2> lipShapeTables)
                {
                    bool valid = true;
                    if (lipShapeTables == null)
                    {
                        valid = false;
                    }
                    else
                    {
                        for (int table = 0; table < lipShapeTables.Count; ++table)
                        {
                            if (lipShapeTables[table].skinnedMeshRenderer == null)
                            {
                                valid = false;
                                break;
                            }
                            for (int shape = 0; shape < lipShapeTables[table].lipShapes.Length; ++shape)
                            {
                                LipShape_v2 lipShape = lipShapeTables[table].lipShapes[shape];
                                if (lipShape > LipShape_v2.Max || lipShape < 0)
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (valid)
                        LipShapeTables = lipShapeTables;
                }

                public void UpdateLipShapes(Dictionary<LipShape_v2, float> lipWeightings)
                {
                    foreach (var table in LipShapeTables)
                        RenderModelLipShape(table, lipWeightings);
                }

                private void RenderModelLipShape(LipShapeTable_v2 lipShapeTable, Dictionary<LipShape_v2, float> weighting)
                {
                    for (int i = 0; i < lipShapeTable.lipShapes.Length; i++)
                    {
                        int targetIndex = (int)lipShapeTable.lipShapes[i];
                        if (targetIndex > (int)LipShape_v2.Max || targetIndex < 0) continue;
                        lipShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(i, weighting[(LipShape_v2)targetIndex] * 100);
                    }
                }
            }
        }
    }
}