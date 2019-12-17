# 🧍 Queue

A [queue](https://en.wikipedia.org/wiki/Queue_(abstract_data_type)) is an example of an abstract data type which follows a **FIFO** order _(First in, first out)_.

It has two primary operations: 
* **enqueue**, which adds an element to the queue, and
* **dequeue**, which removes the earliest added element that was not yet removed.

![Queue](https://i.imgur.com/5Mkd9Q8.png)

## Queue Methods
There are three different ways of creating a queue:
* **Simple**, which slides to the right as items are added and removed,
* **Shunting**, which shunts left every time we remove something, and
* **Circular**, which uses the modulo operation to create a circular structure.
