namespace UnityEngine.UI
{
    [DisallowMultipleComponent]
    [AddComponentMenu("UI/VerticalCurveLayoutGroup(UGUI)")]
    public class VerticalCurveLayoutGroup : VerticalLayoutGroup
    {        
        [SerializeField]
        private AnimationCurve curve;
        [SerializeField]
        private RectTransform viewPort;
        private Vector3[] corners = new Vector3[4];//左下，左上，右上，右下
        protected override void Awake()
        {
            viewPort = transform.parent.GetComponent<RectTransform>();
            viewPort.GetWorldCorners(corners);
        }
        public override void SetLayoutVertical()
        {
            base.SetLayoutVertical();
            //UIList拖动的时候是UIList（Content）滑动，如果ScrollValue变化，滑动 那么需要重新计算水平方向的位置。
            SetChildrenPosX();
        }

        private void SetChildrenPosX()
        {            
            //以下计算是在世界空间下计算
            Vector3 bottomLeftPos = corners[0];
            Vector3 topRightPos = corners[2];
            float totalHeight = topRightPos.y - bottomLeftPos.y;
            float totalWidth = topRightPos.x - bottomLeftPos.x;

            foreach (RectTransform rectTransform in rectChildren)
            {
                Vector3 itemPos = rectTransform.position;

                if (itemPos.y < bottomLeftPos.y || itemPos.y > topRightPos.y)
                {
                    continue;
                }
                float rate = (itemPos.y - bottomLeftPos.y) / totalHeight;
                float offsetXRate = curve.Evaluate(rate);
                float worldPosX = totalWidth * offsetXRate + bottomLeftPos.x;
                rectTransform.position = new Vector3(worldPosX + padding.left * 0.1f, itemPos.y, itemPos.z);
            }
        }
    }
}