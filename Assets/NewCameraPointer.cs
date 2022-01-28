using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraPointer : MonoBehaviour
{
    const float _maxDistance = 10f;
    GameObject _gazedGameObject;
    [SerializeField] LayerMask whatIsGazed;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance, whatIsGazed))
        {
            if (_gazedGameObject != hit.transform.gameObject)
            {
                _gazedGameObject?.SendMessage("OnPointerExit");
                _gazedGameObject = hit.transform.gameObject;
                _gazedGameObject.SendMessage("OnPointerEnter");
            }
            else
            {
                if (_gazedGameObject != null)
                {
                    _gazedGameObject.SendMessage("OnPointerExit");
                    _gazedGameObject = null;
                }
            }
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedGameObject?.SendMessage("OnPointerClick");
        }
    }


}
