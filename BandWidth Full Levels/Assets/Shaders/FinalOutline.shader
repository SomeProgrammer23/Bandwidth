Shader "Custom/FinalOutline"  //Taught by Morgan James
{
    Properties // Variables
    {
        _MainTex("Main Texture (RGB)", 2D) = "white" {} // Texture Property
        _Color("Colour", Color) = (1,1,1,1) // Colour Property
        _OutlineWidth("Outline Width", Range(1.0, 10.0)) = 1.1 // Outline Width Property
        _BlurRadius("Blur Radius", Range(0.0, 20.0)) = 1 // Blur Radius Property
        _Intensity("Blur Intensity", Range(0.0, 1.0)) = 0.01 // Blur Intensity Property
        _DistortColor("Distort Colour", Color) = (1,1,1,1)
        _BumpAmt("Distortion", Range(0, 128)) = 10
        _DistortTex("Distort Texture (RGB)", 2D) = "white" {}
        _BumpMap("Normal Map", 2D) = "bump" {}
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }

        GrabPass{}
        UsePass "Custom/OutlineDistort/OUTLINEDISTORT"
        GrabPass{}
        UsePass "Custom/OutlineBlur/OUTLINEHORIZONTALBLUR"
        GrabPass{}
        UsePass "Custom/OutlineBlur/OUTLINEVERTICALBLUR"
        UsePass"Custom/Outline/OBJECT"
    }

}
