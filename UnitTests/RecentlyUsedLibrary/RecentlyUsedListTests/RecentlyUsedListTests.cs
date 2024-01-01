namespace RecentlyUsedListTests;

public class RecentlyUsedListTests
{
     [Fact]
    public void Constructor_WithValidCapacity_CreatesListWithCapacity()
    {
        // Arrange
        int capacity = 5;

        // Act
        var list = new RecentlyUsedList(capacity);

        // Assert
        Assert.Equal(capacity, list.Capacity);
    }

    [Fact]
    public void Constructor_WithInvalidCapacity_ThrowsArgumentException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new RecentlyUsedList(0));
        Assert.Throws<ArgumentException>(() => new RecentlyUsedList(-1));
    }

    [Fact]
    public void Add_WithValidItem_AddsItemToList()
    {
        // Arrange
        var list = new RecentlyUsedList(3);
        string item = "Apple";

        // Act
        list.Add(item);

        // Assert
        Assert.Equal(1, list.Count);
        Assert.Equal(item, list.GetItem(0));
    }

    [Fact]
    public void Add_WithExistingItem_MovesItemToFrontOfList()
    {
        // Arrange
        var list = new RecentlyUsedList(4);
        list.Add("Apple");
        list.Add("Banana");

        // Act
        list.Add("Apple");

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal("Apple", list.GetItem(0));
    }

    [Fact]
    public void Add_WithFullCapacity_DropsLastItemWhenAddingNew()
    {
        // Arrange
        var list = new RecentlyUsedList(2);
        list.Add("Apple");
        list.Add("Banana");

        // Act
        list.Add("Orange");

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal("Orange", list.GetItem(0));
        Assert.Equal("Banana", list.GetItem(1));
    }

    [Fact]
    public void Add_WithNullOrEmptyItem_ThrowsArgumentException()
    {
        // Arrange
        var list = new RecentlyUsedList();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => list.Add(null));
        Assert.Throws<ArgumentException>(() => list.Add(string.Empty));
    }

    [Fact]
    public void GetItem_WithValidIndex_ReturnsCorrectItem()
    {
        // Arrange
        var list = new RecentlyUsedList(3);
        list.Add("Apple");
        list.Add("Banana");
        list.Add("Orange");

        // Act
        var item = list.GetItem(1);

        // Assert
        Assert.Equal("Banana", item);
    }

    [Fact]
    public void GetItem_WithInvalidIndex_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        var list = new RecentlyUsedList();
        list.Add("Apple");

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => list.GetItem(1));
        Assert.Throws<IndexOutOfRangeException>(() => list.GetItem(-1));
    }
}