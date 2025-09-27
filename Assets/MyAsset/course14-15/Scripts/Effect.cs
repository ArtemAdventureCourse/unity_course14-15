using UnityEngine;

public class Effect : MonoBehaviour
{
   [SerializeField ]private  ParticleSystem _particleSystem;

    private void PlayEffect(Item item)=> _particleSystem.Play(item);

    public void Play(Item item) => PlayEffect(item); 

    private void SetPositionForFx(Item item)=> transform.position = item.transform.position;

    public void SetPosition(Item item)=> SetPositionForFx(item);
}
