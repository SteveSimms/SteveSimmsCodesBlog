// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const log = console.log
var greetings = [
    'Welcome to Steve Simms codes',
    'Welcome to the blog',
    'Stick Around For A while']




const rndmGreetingGenerator = () => {

    Math.floor(Math.random() * (greetings.length))
    greetings[rndmGreetingGenerator]

}

let welcome = (greeting) => log(greeting)

welcome(rndmGreetingGenerator())


