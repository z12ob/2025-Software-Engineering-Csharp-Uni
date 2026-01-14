Facade facade = new Facade();
facade.StartMovie();
facade.EndMovie();

DVDplayer dvdplayer = new DVDplayer();
Screen screen = new Screen();
Lights lights = new Lights();
Projector projector = new Projector();

screen.Lower();
lights.Off();
projector.On();
dvdplayer.Play();

dvdplayer.Stop();
lights.On();
projector.Off();
screen.Upper();