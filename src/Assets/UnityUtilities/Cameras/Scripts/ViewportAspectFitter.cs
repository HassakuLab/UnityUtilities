using UnityEngine;

namespace HassakuLab.Utils.Cameras
{
    /// <summary>
    /// set Camera.rect using specific aspect ratio in Awake()
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class ViewportAspectFitter : MonoBehaviour
    {
        [SerializeField] private Rect containerViewport = new Rect(0f, 0f, 1f, 1f);

        [SerializeField] private float referenceWidth = 1f;
        [SerializeField] private float referenceHeight = 1f;

        private Camera _camera;

        //  ex) w : h = 16 : 9 => 9 / 16
        private float AspectRatio
        {
            get
            {
                if (Mathf.Approximately(referenceWidth, 0f)) return referenceHeight;
                return referenceHeight / referenceWidth;
            }
        }

        private float ContainerWidth => containerViewport.width * Screen.width;
        private float ContainerHeight => containerViewport.height * Screen.height;

        //  ex) w : h = 16 : 9 => 9 / 16
        private float ContainerAspectRatio
        {
            get
            {
                float w = ContainerWidth;
                float h = ContainerHeight;
                return w == 0 ? h : h / w;
            }
        }
        
        private void Awake()
        {
            _camera = GetComponent<Camera>();
            AdjustRect();
        }

        private void AdjustRect()
        {
            float gameAspect = AspectRatio;
            float containerAspect = ContainerAspectRatio;
            
            if (gameAspect > containerAspect)
            {
                float widthRatio = containerViewport.width * (
                    Mathf.Approximately(containerAspect, 0f) ? 1f : containerAspect / gameAspect
                    );
                float bandRatio = (containerViewport.width - widthRatio) / 2f;
                _camera.rect = new Rect(containerViewport.x + bandRatio, containerViewport.y, widthRatio, containerViewport.height);
            }
            else
            {
                float heightRatio = containerViewport.height * (
                    Mathf.Approximately(gameAspect, 0f) ? 1f : gameAspect / containerAspect
                    );
                float bandRatio = (containerViewport.height - heightRatio) / 2f;
                _camera.rect = new Rect(containerViewport.x, containerViewport.y + bandRatio, containerViewport.width, heightRatio);
            }
        }
    }
}
