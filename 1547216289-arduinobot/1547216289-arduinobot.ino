#include <Arduino.h>
#include <Wire.h>
#include <SoftwareSerial.h>
#include <MeMCore.h>

MeBuzzer buzzer;
MeDCMotor motorG(M1);
MeDCMotor motorD(M2);
MeLineFollower lineFinder(PORT_2);
MeRGBLed led(PORT_7);
MeUltrasonicSensor ultraSensor(PORT_3);
MeLEDMatrix ledMX(PORT_1);

char text_off[] = "OFF";
char text_on[] = "ON";
bool running = false;
int speed = 100;

void setup() {
  pinMode(A7, INPUT);
}

void loop() {
  if (analogRead(A7) < 512) {
    running = !running;
    motorG.stop();
    motorD.stop();
    while (analogRead(A7) < 512) {
    }
  }
  
  if (!running) {
    ledMX.setBrightness(8);
    ledMX.drawStr(0, 7, text_off);
    return;
  }
  
  ledMX.setBrightness(8);
  ledMX.drawStr(2, 7, text_on);
  
  int usv = ultraSensor.distanceCm();
  
  if (usv < 10) {
    motorG.stop();
    motorD.stop();
    music();
  }
  else {
    int lfv = lineFinder.readSensors();
    
    if (lfv == 0) {
      if (speed < 255) {
        speed++;
      }
      motorG.run(-speed);
      motorD.run(speed);
      led.setColorAt(0, 0, 255, 0);
      led.setColorAt(1, 0, 255, 0);
    }
    else if (lfv == 1) {
      speed = 100;
      motorG.run(speed);
      motorD.run(speed);
      led.setColorAt(0, 0, 255, 0);
      led.setColorAt(1, 255, 0, 0);
    }
    else if (lfv == 2) {
      speed = 100;
      motorG.run(-speed);
      motorD.run(-speed);
      led.setColorAt(0, 255, 0, 0);
      led.setColorAt(1, 0, 255, 0);
    }
    else if (lfv == 3) {
      speed = 100;
      motorG.run(speed);
      motorD.run(-speed);
      led.setColorAt(0, 255, 0, 0);
      led.setColorAt(1, 255, 0, 0);
    }
  }

  delay(1);
}

int NOTE_1 = 523;
int NOTE_2 = 587;
int NOTE_3 = 659;
int NOTE_4 = 739;
int NOTE_5 = 783;
int NOTE_WHITE = 100;
int NOTE_BLACK = 50;

void music() {
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_4, NOTE_BLACK);
  buzzer.tone(NOTE_5, NOTE_BLACK);
  
  buzzer.tone(NOTE_5, NOTE_BLACK);
  buzzer.tone(NOTE_4, NOTE_BLACK);
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_2, NOTE_BLACK);

  buzzer.tone(NOTE_1, NOTE_BLACK);
  buzzer.tone(NOTE_1, NOTE_BLACK);
  buzzer.tone(NOTE_2, NOTE_BLACK);
  buzzer.tone(NOTE_3, NOTE_BLACK);
  
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_2, NOTE_BLACK);
  buzzer.tone(NOTE_2, NOTE_WHITE);
  
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_4, NOTE_BLACK);
  buzzer.tone(NOTE_5, NOTE_BLACK);
  
  buzzer.tone(NOTE_5, NOTE_BLACK);
  buzzer.tone(NOTE_4, NOTE_BLACK);
  buzzer.tone(NOTE_3, NOTE_BLACK);
  buzzer.tone(NOTE_2, NOTE_BLACK);

  buzzer.tone(NOTE_1, NOTE_BLACK);
  buzzer.tone(NOTE_1, NOTE_BLACK);
  buzzer.tone(NOTE_2, NOTE_BLACK);
  buzzer.tone(NOTE_3, NOTE_BLACK);
  
  buzzer.tone(NOTE_2, NOTE_BLACK);
  buzzer.tone(NOTE_1, NOTE_BLACK);
  buzzer.tone(NOTE_1, NOTE_WHITE);
  
  buzzer.noTone();
  delay(100);
}
