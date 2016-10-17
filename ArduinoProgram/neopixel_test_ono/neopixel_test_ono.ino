#include <Adafruit_NeoPixel.h>
#include <avr/power.h>

char input[200];

void setup() {
  Serial.begin(115200);
  }

void loop() {
   if (Serial.available()) {
    input[0] = Serial.read();
    Serial.print(input);
   } 
}
   





