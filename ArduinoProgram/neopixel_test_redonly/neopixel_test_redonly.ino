#include <Adafruit_NeoPixel.h>
#include <avr/power.h>

#define PIN1        6
#define PIN2        7
#define NUMPIXELS   50

class RGB {
  public: bool reach = true;
  private:int lerpSpeed = 10;
  public: int r, g, b, tr, tg, tb;
  public: void SetColor (int red, int green, int blue){
    r = red; g = green; b = blue;
  }
  public: void SetTargetColor (int red, int green, int blue){
    r = red; g = green; b = blue;
  }
  public: void TargetLerp () {
    int diffr = tr - r;
    int diffg = tg - g;
    int diffb = tb - b;
    int vr = (diffr / lerpSpeed); 
    int vg = (diffg / lerpSpeed); 
    int vb= (diffb / lerpSpeed);
    r += vr;
    g += vg;
    b += vb;
    if (abs(diffr) < lerpSpeed*2 && abs(diffg) < lerpSpeed*2 && abs(diffb) < lerpSpeed*2) {
      reach = true;
    } else reach = false;
  }
  
};
RGB color;

Adafruit_NeoPixel pixels1 = Adafruit_NeoPixel(NUMPIXELS, PIN1, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel pixels2 = Adafruit_NeoPixel(NUMPIXELS, PIN2, NEO_GRB + NEO_KHZ800);
int delayVal = 20; 

void setup() {
  pixels1.begin();
  pixels2.begin();
}

void loop() {
  for(int i=0;i <NUMPIXELS; i++){
    pixels1.setPixelColor(i, pixels1.Color(255,0,150)); 
  }
  delay(delayVal);
}

void updateLED (int num, RGB c) {
  pixels1.setPixelColor(num, pixels1.Color(c.r, c.g, c.b));
  pixels1.show(); 
  pixels2.setPixelColor(num, pixels2.Color(c.r, c.g, c.b));
  pixels2.show(); 
}



