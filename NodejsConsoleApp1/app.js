'use strict';
// Task 1
var statement = "I can eat banannas all day";
var banannas = statement.slice(10,19).toUpperCase();
console.log(banannas);

//Task 2

var cars = ["Volvo", "BMW", "Saab"];
console.log(cars[1]);
cars[0] = "Zastava";
var lastCar = cars.pop(cars.slice(-1));
console.log(lastCar);
cars.push("Audi");
var splicedCars = cars.splice(0, 9);
console.log(splicedCars);
