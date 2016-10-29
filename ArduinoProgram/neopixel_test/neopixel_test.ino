#include <Adafruit_NeoPixel.h>
#include <avr/power.h>

#define PIN        6
#define NUMPIXELS  50

Adafruit_NeoPixel pixels = Adafruit_NeoPixel(NUMPIXELS, PIN1, NEO_GRB + NEO_KHZ800);
int delayVal = 20; 
int current = 0;

class LED {
  public: int ledNum;
  private:int lerpSpeed = 10;
  private:int darkColor = 0;
  public: int r, g, b;
  public: void SetColor (int red, int green, int blue){
    r = red; g = green; b = blue;
    updateLED();
  }
  public: void ToDark () {
    int diffr = darkColor - r;
    int diffg = darkColor - g;
    int diffb = darkColor - b;
    int vr = (diffr / lerpSpeed); 
    int vg = (diffg / lerpSpeed); 
    int vb = (diffb / lerpSpeed);
    r += vr;
    g += vg;
    b += vb;
    updateLED();
  }

  public: void updateLED () {
    pixels.setPixelColor(ledNum, pixels.Color(r,g,b));
    pixels.show(); 
  }
};
LED led[NUMPIXELS];


void setup() { 
  pixels.begin(); 
  for (int i=0; i<NUMPIXELS; i++) {
    led[i].ToDark();
  }
}

void loop() {
  for (int i=0; i<NUMPIXELS; i++) {
    led[i].ToDark();
  }
  
  led[current].SetColor( 255, 0, 150 );
  
  if (current < NUMPIXELS-1) {
    current += 1;
  } else {
    current = 0;
  }
  
  delay(delayVal);
}





