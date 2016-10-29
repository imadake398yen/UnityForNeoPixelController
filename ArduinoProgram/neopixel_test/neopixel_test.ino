#include <Adafruit_NeoPixel.h>
#include <avr/power.h>

#define PIN        6
#define NUMPIXELS  50

Adafruit_NeoPixel pixels = Adafruit_NeoPixel(NUMPIXELS, PIN1, NEO_GRB + NEO_KHZ800);

int moveDelay = 20;     //LEDの色の流れる速度
int pulseDelay = 100;   //LEDが流れる周期
int colorSpeed = 10;    //LED1個単位の黒に変わる速度
int current = 0;        //名前迷った。ごめん。

class LED {
  public: int ledNum;
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
    int vr = (diffr / colorSpeed); 
    int vg = (diffg / colorSpeed); 
    int vb = (diffb / colorSpeed);
    r += vr;
    g += vg;
    b += vb;
    updateLED();
  }
  public: void updateLED () {
    pixels.setPixelColor( ledNum, pixels.Color(r,g,b) );
    pixels.show(); 
  }
};
LED led[NUMPIXELS];

void setup() { 
  pixels.begin(); 
  for (int i=0; i<NUMPIXELS; i++) {
    led[i].ledNum = i;
  }
}

void loop() {
  if ( current < NUMPIXELS-1 ) {
    for (int i=0; i<NUMPIXELS; i++) {
      led[i].ToDark();
    }
    led[current].SetColor( 255, 0, 150 );
    delay( moveDelay );
    current += 1;
  } else {
    delay( pulseDelay );
    current = 0;
  }
}





