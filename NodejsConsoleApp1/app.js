'use strict';
// Task 1
var statement = "I can eat banannas all day";
var banannas = statement.slice(10,19).toUpperCase();
console.log(banannas);

//Task 2

var cars = ["Saab","Volvo","BMW"];
var carBMW = cars[2];
cars[0] = "Zastava";
var lastCar = cars.slice(-1);
cars.pop(lastCar);
cars.push("Audi");
console.log(cars);
