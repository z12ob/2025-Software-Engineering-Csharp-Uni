interface Animal {
    void makeSound();
}
class Dog implements Animal {
    public void makeSound() {
        System.out.println("ყეფა");
    }
}
class Cat implements Animal {
    public void makeSound() {
        System.out.println("მიაუ");
    }
}
class AnimalFactory {
    public static Animal createAnimal(String type) {
        if (type.equalsIgnoreCase("dog")) {
            return new Dog();
        } else if (type.equalsIgnoreCase("cat")) {
            return new Cat();
        }
        return null;
}
}

// გამოყენება
// Animal myPet = AnimalFactory.createAnimal("dog");
// myPet.makeSound();