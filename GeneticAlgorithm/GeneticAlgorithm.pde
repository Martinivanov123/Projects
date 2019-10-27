Population test;
PVector goal = new PVector(400, 30);

void setup() {
  size(800, 700);
  test = new Population(1000);
}

void draw() {
  background(255);
  fill(255, 0, 0);
  ellipse(goal.x, goal.y, 10, 10);

  if (test.allDotsDead()) {
    test.calculateFitness();
    test.naturalSelection();
    test.mutate();
  } 
  
  else {
    test.update();
    test.show();
  }
}
