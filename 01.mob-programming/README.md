# Mob Programming
## Connection - Web Hunt (10')
In pairs, deep dive into the workshop topic - 5':
- What is `mob programming`? 
  - What is the difference between `mob programming` and `ensemble programming`?
- What values can it bring?

Group sharing - 5'

![Web Hunt](img/hunt.png)

## Concepts
[![Pair Programming explained](img/a-day-of-mob-programming.png)](https://youtu.be/dVqUcNKVbYg)

- What did you see?
- What do you think about it?
- What about the roles?
- What about meetings?

![All the brilliant minds](img/brilliant-minds.png)

> No delays, a real flow

### Use cases
- Create a new project / solution / system
  - Do it as a mob, it:
    - Involves every team member in decisions taking
    - Shares instantly knowledge inside the team
    - Allows to create the best system possible: "alone we go faster together we go further"
- Open a new `User Story`
  - You can do it as a whole team
  - Instead of having big discussions on how to split it theoretically
    - Take some times in mob and design the solution together
    - Put some `TODOs` in the code that represents the work to do
  - By doing so, you will agree before the implementation on what and how to do it
    - Spending much less time in `code reviews` later on
- On-board new joiners on your team standards

![Work effectively with mob programming](img/working-effectively-with-pair-mob-programming.png)

## Concrete Practice - Crappy some code
`The secret art of making yourself indispensable by writing crappy code !!!`

### Kata
In mob:
- Choose a code in a language you want to work with (`C#`, `java`, `scala`)
- Your objective : Apply CDD to make the code so crappy that other people won't be able to understand it
  - Follow the golden rules described below

![Crappy-Driven-Development](img/crappy-driven-development.png)

- Make it in Baby steps (crappy 1 thing at a time)
- You have `80 minutes` to make as many cycles as possible :
  - Be creative
  - The more brainfuck it is the better
  - Tests are green before and at the end of your refactoring

### Mob roles
Use [mobtime](https://mobti.me/) and configure below roles :
* Turn Duration : 5 minutes
* Create the 4 roles presented below

![mob config](img/mob-config.png)

#### Driver
![driver](img/driver.png)

- Write the code according to the navigator's specification
- Listen intently to the navigators instructions
- Ask questions wherever there is a lack of clarity

#### Navigator
![navigator](img/navigator.png)

- Dictates the code that is to be written - the 'what'
- Clearly communicates what code to write
- Explains 'why' they have chosen the particular solution to this problem
- Check for syntax / type errors as the Driver drives

#### Scribe
![scribe](img/scribe.png)

- Write down the goals of each cycle in mobtime or other
- Explain why it has been decided
- For each stuff learned in the mob, write it as well

![goals examples](img/example.png)

#### Crappier
![crappier](img/crappier.png)

- Anticipate what can be crappier
- Write down ideas that emerge in his/he minds and other ideas as well

### Crappy ideas
If at one point you struggle to find crappy ideas here is a cheat sheet of [crappy ideas](files/crappy-ideas.pdf).

### Review
At the end, each mob presents the new version of the production code

## Conclusion - Reflect
Take a few minutes to reflect and ask questions :
- What did you learn from this kata and from the mob?
- How does it differ to your current way of working?
- How mob programming could be applied in your current context?
  - When?
- What would you expect from it?

## Resources
- [Mob Programming - A Whole Team Approach by Woody Zuill](https://leanpub.com/mobprogramming)
- [The Surprisingly Inclusive Benefits of Mob Programming at Cucumber](https://cucumber.io/blog/bdd/inclusive-benefits-of-mob-programming/)
- [Puzzle-Driven Development](https://www.yegor256.com/2010/03/04/pdd.html)
- [Crappy-Driven Development](https://github.com/ythirion/crappy-driven-development)
- [Mobtime](https://mobti.me/)
- [Ensemble Enablers](https://proagileab.github.io/EnsembleEnablers/)
