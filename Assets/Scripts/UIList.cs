using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityEngine.UI {

    public class UIList : UIBehaviour
    {
        [SerializeField]
        private ScrollRect scrollRect;
        [SerializeField]
        private GameObject prototype;
        private int itemCount;
        private List<GameObject> listItem = new List<GameObject>();
        private LayoutGroup layoutGroup;

        protected override void Awake()
        {
            base.Awake();
            prototype.SetActive(false);
            layoutGroup = GetComponent<LayoutGroup>();
        }

        protected override void Start()
        {
            base.Start();

            //当ScrollRect滑动的时候，重绘每个物体
            if(layoutGroup != null && layoutGroup is VerticalCurveLayoutGroup)
            {
                scrollRect.onValueChanged.AddListener((delta) =>
                {
                    layoutGroup.SetLayoutVertical();
                });
            }
            
            //绘制10个物体
            DrawList(10);
        }

        public void DrawList(int count, System.Action<GameObject> action = null)
        {
            for (int i = 0; i < count; i++)
            {
                var obj = GameObject.Instantiate(prototype);
                obj.transform.SetParent(this.transform, false); //false表明生成出來的子物体并不受父物体影响，保持大小和位置不变
                obj.SetActive(true);
                listItem.Add(obj);
                if (action != null)
                {
                    action.Invoke(obj);
                }
            }
        }
    }
}

