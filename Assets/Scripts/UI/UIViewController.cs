using System;
using UnityEngine;

namespace GHOST.UI
{
    public class UIViewController : MonoBehaviour, IVisible
    {
        [SerializeField] private CanvasGroup canvas;

        [SerializeField] private UIViewAnimator uiViewAnimator;

        [SerializeField] private bool startVisible;

        [SerializeField] private bool showEndUi;

        private RectTransform _rectTransform;
        private Vector2 _originPosition;

        public GhostlyTimer ghost;

        public bool endscreen;



        public void Update()
        {
            if (ghost == null)
            {
                ghost = FindObjectOfType<GhostlyTimer>();
            }

            if (canvas.alpha == 0 && ghost.organsPlaced == 3 && endscreen)
            {
                ShowInstant();
            }
        }

        private void Awake()
        {
            _rectTransform = canvas.GetComponent<RectTransform>();
            _originPosition = _rectTransform.anchoredPosition;
            
            if(!startVisible)
            {
                HideInstant();
            }
            else
            {
                ShowInstant();
            }
        }

        public void MoveInView() => _rectTransform.Reset();

        public void MoveOutOfView() => _rectTransform.Move(_originPosition);

        public void HideInstant()
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            MoveOutOfView();
        }

        public void ShowInstant ()
        {
            canvas.alpha = 1;
            canvas.interactable = true;
            MoveInView();
        }

        public void Hide()
        {
            uiViewAnimator.Hide();
            MoveOutOfView();
        }

        public void Show()
        {
            uiViewAnimator.Show();
            MoveInView();
        }
    }

    public static class Extensions
    {
        public static void Move(this RectTransform rect, Vector2 toPosition)
        {
            rect.anchoredPosition = toPosition;
        }
        
        public static void Reset(this RectTransform rect)
        {
             rect.anchoredPosition = Vector2.zero;
        }
    }
}