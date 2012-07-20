FretLight-Animator
==================
A C# project for manipulating and animating the LEDs on a Optek Fretlight Guitar

<a href="http://www.fretlight.com/">These guys</a> made a guitar with LEDs embedded in the neck. Unfortunately they only used this great technology to display chord shapes and other guitar-related patterns. That disappointed me, because I believe in the freedom to use your tools in whatever way you want. So I wrote an app that gives the user full control of the LEDs. In addition to that, I went ahead and built a GUI-driven animator so that the few people in the world that actually own a Fretlight guitar could create their own custom animations, for fun mostly. I also implemented <a href="http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life">Conway's Game of Life</a> for my own entertainment and because its a cool demo of what my code can do. 
So here's a video of it running the simulation.
<a href="http://www.youtube.com/watch?v=WIm-njaGjdA"> Video</a>

Codebase relies on <a href="http://sourceforge.net/projects/libusbdotnet/">Libusb.net</a> in order to communicate with the guitar via usb

Some of the features of my app include:
- Variable animation speed, controlled with a slider
- Loosely-coupled GUI/Guitar settings, so you can observe animations even without attaching a guitar
- A Rule-based framework for adding new animations to the code
- XML-Based save files for the rules the user creates