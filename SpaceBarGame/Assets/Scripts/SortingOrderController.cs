using UnityEngine;
using System.Collections.Generic;

public class SortingOrderController : MonoBehaviour {

    [System.Serializable]
    public class RendererMapping {
        public Renderer renderer;
        public int originalOrder;
        public int currentOrder;

        public RendererMapping(Renderer ren) {
            renderer = ren;
            originalOrder = ren.sortingOrder;

            renderer.sortingLayerName = "default";
        }

        public void UpdateInfo() {
            currentOrder = renderer.sortingOrder;
        }
    }

    Transform tf;
    Renderer renderer;

    public List<RendererMapping> renMapList;

    //public List<Renderer> renList;
    //public List<int> renListValues;//creatd in LogRendererListValues

    public int order;

    void Awake() {
        
        tf = GetComponent<Transform>();
        renderer = GetComponent<Renderer>();

        renMapList = new List<RendererMapping>();

        //renList = new List<Renderer>();
        
    }

	// Use this for initialization
	void Start () {
        AssembleRendererList(tf);
        //Debug.Log(renList.Count);

        //LogRendererListValues(renList);
	}
	
	// Update is called once per frame
	void Update () {
        //renderer.sortingOrder = (int) (tf.position.z * 1000.0f);
        //renderer.sortingOrder = order;

        foreach (RendererMapping renMap in renMapList) {
            renMap.renderer.sortingOrder = renMap.originalOrder + (int)(tf.position.z * 10.0f);
            renMap.UpdateInfo();
        }
	}

    private void AssembleRendererList(Transform inTf) {
        if (inTf.childCount > 0) {
            foreach (Transform subTf in inTf) {
                AssembleRendererList(subTf);
            }
        }

        if (inTf.GetComponent<Renderer>() != null) {
            //renList.Add(inTf.GetComponent<Renderer>());
            renMapList.Add(new RendererMapping(inTf.GetComponent<Renderer>()));
        }
    }

    /*
    private void LogRendererListValues(List<Renderer> inRenList) {
        renListValues = new List<int>();

        for (int i = 0; i < inRenList.Count; ++i) {
            renListValues.Add(inRenList[i].sortingOrder);
        }
    }
    */
}
