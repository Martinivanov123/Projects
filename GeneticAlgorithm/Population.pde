class Population{
  Dot[] dots;
  float fitnessSum;
  int gen = 1;
  
  Population(int size){
    dots = new Dot[size];
    for(int i = 0; i < size; i++){
      dots[i] = new Dot();
    }
  }
  
  void show(){
    for(int i = 0; i < dots.length; i++){
      dots[i].show();
    }
  }
  
  void update(){
    for(int i = 0; i < dots.length; i++){
      dots[i].update();
    }
  }
  
  void calculateFitness(){
    for(int i = 0; i < dots.length; i++){
      dots[i].calculateFitness();
    }
  }
  
  boolean allDotsDead(){
    for(int i = 0; i < dots.length; i++){
      if(!dots[i].isDead && !dots[i].reachedGoal){
        return false;
      }
    }
    
    return true;
  }
  
  void naturalSelection(){
    Dot[] newDots = new Dot[dots.length];
    calculateFitnessSum();
    
    for(int i = 0; i < dots.length; i++){
      Dot parent = selectParent();
      newDots[i] = parent.makeBaby();
    }
    
    dots = newDots.clone();
    gen++;
  }
  
  void calculateFitnessSum(){
    fitnessSum = 0;
    for(int i = 0; i < dots.length; i++){
      fitnessSum += dots[i].fitness;
    }
  }
  
  Dot selectParent(){
    float rand = random(fitnessSum);
    float runningSum = 0;
    
    for(int i = 0; i < dots.length; i++){
      runningSum += dots[i].fitness;
      if(runningSum > rand){
        return dots[i];
      }
    }
    
    return null;
  }
  
  void mutate(){
    for(int i = 0; i < dots.length; i++){
      dots[i].brain.mutate();
    }
  }
}
