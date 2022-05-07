// using UnityEngine;

// public class MyClass : MonoBehaviour
// {
//     [SerializeField] private Animator m_Animator;
//     private bool _isGamePaused = false;

//     public bool IsGamePaused { get => _isGamePaused; private set => _isGamePaused = value; }

//     void Start()
//     {
//         m_Animator.SetBool("Hide", false);
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.name == "player" && IsGamePaused == false)
//         {
//             if (this.gameObject.GetComponent<LeftRight>() != null)
//             {
//                 this.gameObject.GetComponent<LeftRight>().RangeOfMovement = 0;
//             }
//             m_Animator.SetBool("Hide", true);
//         }
//     }
//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if (this.gameObject.GetComponent<LeftRight>() != null)
//         {
//             this.gameObject.GetComponent<LeftRight>().RangeOfMovement = 9.5f;
//         }
//         m_Animator.SetBool("Hide", false);
//     }
// }
