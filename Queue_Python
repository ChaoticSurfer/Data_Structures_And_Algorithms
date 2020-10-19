class Queue:
    """Queue implementation as a list"""

    def __init__(self, Arr=None):
        """Create new queue"""
        if isinstance(Arr, type(None)):
            Arr = []
        self._items = Arr
        self.index = -1

    def peek(self):
        '''Peek at first element'''
        return self._items[-1]

    def is_empty(self):
        """Check if the queue is empty"""
        return not bool(self._items)

    def enqueue(self, item):
        """Add an item to the queue"""
        self._items.insert(0, item)

    def dequeue(self):
        """Remove an item from the queue"""
        return self._items.pop()

    def size(self):
        """Get the number of items in the queue"""
        return len(self._items)

    def generator(self):
        return (i for i in self._items)

    def to_list(self):
        return self._items

    def __iter__(self):
        return self

    def __next__(self):
        self.index += 1
        if self.index >= len(self._items):
            self.index = -1
            raise StopIteration
        else:
            return self._items[self.index]
