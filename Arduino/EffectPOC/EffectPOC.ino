//Effect Proof Of Concepts
#include <Adafruit_NeoPixel.h>

#define PIN 8
#define NUM_LEDS 1 // Two 16-LED NeoPixel rings
#define FPS      30 // Animation frames/second (ish)

Adafruit_NeoPixel strip = Adafruit_NeoPixel(NUM_LEDS, PIN, NEO_GRB + NEO_KHZ800);

void setup() {

  strip.begin();
  strip.show(); // Initialize all pixels to 'off'
}

uint32_t prevTime = 0L;       // For animation timing
uint32_t frameCounter = 0L;   // For animation triggering

uint32_t brightnessOn = 4; //seconds
uint32_t brightnessOff = 2; //seconds
uint32_t nextBrightness = brightnessOn*FPS; //initialized for startOn


void loop() {
  uint32_t t;
  for (;;) {
    t = micros();                            // Current time
    if ((t - prevTime) >= (1000000L / FPS)) { // 1/30 sec elapsed?
      prevTime = t;
      frameCounter++;
      break;                                 // Yes, go update LEDs
    }                                        // otherwise...
  }
  // Displaying the different wavetype effects, square, needle, triangle, sine,
  squareWave(255, 0, 5000, 2500, 1);   //offstate set to zero
}

void squareWave(uint8_t onState, uint8_t offState, uint16_t onDuration, uint16_t offDuration, bool startOn) {
  if (frameCounter == nextBrightness) {
    if (strip.getBrightness() == onState) {
      strip.setBrightness(offState);
      strip.show();
      nextBrightness+=(brightnessOff*FPS);
    } else {
      strip.setBrightness(onState);
      strip.setPixelColor(0, strip.Color(0, 255, 0));
      strip.show();
      nextBrightness+=(brightnessOn*FPS);
    }
  }
}



// Fill the dots one after the other with a color
void colorWipe(uint32_t c, uint8_t wait) {
  for (uint16_t i = 0; i < strip.numPixels(); i++) {
    strip.setPixelColor(i, c);
    strip.show();
    delay(wait);
  }
}

// Slightly different, this makes the rainbow equally distributed throughout
void rainbowCycle(uint8_t wait) {
  uint16_t i, j;

  for (j = 0; j < 256 * 5; j++) { // 5 cycles of all colors on wheel
    for (i = 0; i < strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel(((i * 256 / strip.numPixels()) + j) & 255));
    }
    strip.show();
    delay(wait);
  }
}

// Input a value 0 to 255 to get a color value.
// The colours are a transition r - g - b - back to r.
uint32_t Wheel(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if (WheelPos < 85) {
    return strip.Color(255 - WheelPos * 3, 0, WheelPos * 3);
  } else if (WheelPos < 170) {
    WheelPos -= 85;
    return strip.Color(0, WheelPos * 3, 255 - WheelPos * 3);
  } else {
    WheelPos -= 170;
    return strip.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
  }
}
