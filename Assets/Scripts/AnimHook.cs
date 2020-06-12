using ChessPrototype.Pieces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class AnimHook : MonoBehaviour
    {
        public Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void OpenDamageColliders()
        {
            Piece piece = GetComponentInParent<Piece>();
            WeaponHook hook = piece.GetComponentInChildren<WeaponHook>(true);

            hook.gameObject.SetActive(true);
        }

        public void CloseDamageColliders()
        {
            Piece piece = GetComponentInParent<Piece>();
            WeaponHook hook = piece.GetComponentInChildren<WeaponHook>(true);

            hook.gameObject.SetActive(false);
        }

        public void PlayAnimation(string animName)
        {
            anim.CrossFade(animName, 0.2f);
        }
    }
}