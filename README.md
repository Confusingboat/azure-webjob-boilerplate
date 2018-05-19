## What is this?
It's a boilerplate for a one-off .NET Core Azure WebJob (crontab or manually triggered).

## What's a boilerplate?

In computer programming, boilerplate code or boilerplate refers to sections of code that have to be included in many places with little or no alteration.

## Why not just make it a library instead?

Official answer: doing it this way provides a simple example for those who are new to WebJobs.  
Real answer: I'm too lazy and couldn't be bothered.

## What's a WebJob?

A snazzy new buzzword for that decrepit _Hello World!_ example you call code that runs on somebody else's computer.

## How do I use it?

Literally just run
```
dotnet restore
dotnet publish
```
or `right-click > Publish` and follow the wizard prompts of you're a scrub.

Then just zip up the publish directory and push that shit to Azure and watch it do nothing but waste your CPU time.

## Can I make it do xyz?

I doubt it.
