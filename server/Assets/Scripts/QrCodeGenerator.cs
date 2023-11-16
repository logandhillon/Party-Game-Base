using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QrCodeGenerator: MonoBehaviour {
    [SerializeField] private RawImage barcodeImage;
    [SerializeField] private int size;
    private Texture2D texture;

    void Start() {
        texture = new Texture2D(size, size);
    }

    private void Encode(string text) {
        Color32[] pixels = new BarcodeWriter {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions {
                Height = size,
                Width = size
            }
        }.Write(text);
        texture.SetPixels32(pixels);
        texture.Apply();
        barcodeImage.texture = texture; 
    }
}