using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareManShootTetris.Utils 
{ 
    public static class LayerMaskExtensions 
    {
        //Thanks to British Guy in Sweden
        //URL code: https://britishguyinsweden.com/2019/10/09/unity-checking-a-gameobjects-layer-against-multiple-layermasks/
        public static bool IsInLayerMasks(this GameObject gameObject, int layerMasks) 
        {
            return (layerMasks == (layerMasks | (1 << gameObject.layer)));
        }


    }


}
