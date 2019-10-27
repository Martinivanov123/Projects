class Dot {
  PVector pos;
  PVector vel;
  PVector acc;
  Brain brain;
  boolean isDead = false;
  boolean reachedGoal = false;
  
  float fitness = 0;
  
  Dot() {
    pos = new PVector(width/2, height - 10);
    vel = new PVector(0, 0);
    acc = new PVector(0, 0);

    brain = new Brain(400);
  }

  void show() {
    fill(0);
    ellipse(pos.x, pos.y, 4, 4);
  }

  void move() {
    if (brain.directions.length > brain.step) {
      acc = brain.directions[brain.step];
      brain.step++;
    } else {
      isDead = true;
    }

    vel.add(acc);
    vel.limit(5);
    pos.add(vel);
  }

  void update() {
    if (!isDead && !reachedGoal) {
      move();
      if ((pos.x < 2 ||pos.y < 2) || (pos.x > width - 2 || pos.y > height - 2)) {
        isDead = true;
      }
      
      else if(dist(pos.x, pos.y, goal.x, goal.y) < 5){
        reachedGoal = true;
      }
    }
  }
  
  void calculateFitness(){
    if(reachedGoal){
      fitness = 1.0/(float)(brain.step * brain.step);
    }
    
    else{
      float distanceToGoal = dist(pos.x, pos.y, goal.x, goal.y);
      fitness = 1.0/(distanceToGoal * distanceToGoal);
    }
  }
  
  Dot makeBaby(){
    Dot baby = new Dot();
    baby.brain = brain.clone();
    return baby;
  }
}
