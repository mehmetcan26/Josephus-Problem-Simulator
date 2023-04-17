// See https://aka.ms/new-console-template for more information
var start = DateTime.Now;
int soldierCount = 4;
int killedSoldiers = 0;

LinkedNode[] soldierList = new LinkedNode[soldierCount];


for (int i = 1; i < soldierCount + 1; i++)
{
    LinkedNode soldier = new() { Alive = true, Id = i, Next = null };
    soldierList[i - 1] = soldier;
}

for (int i = 0; i < soldierCount; i++)
{
    if (i == soldierCount - 1)
    {
        soldierList[i].Next = soldierList[0];
    }
    else
    {
        soldierList[i].Next = soldierList[i + 1];
    }
}

LinkedNode Murderer = soldierList[0];

//Let the killing begin
while (killedSoldiers != soldierCount - 1)
{
    if (!Murderer.Alive)
    {
        Murderer = Murderer.Next;
        continue;
    }
    bool possible = Murderer.Murder(Murderer.Next);

    if (possible)
    {
        Murderer = Murderer.Next;
    }
    else
    {
        Console.WriteLine($"The winner is {Murderer.Id}");
        break;
    }
}
var end = DateTime.Now;
Console.WriteLine($"{(end-start).TotalMilliseconds}");

class LinkedNode
{
    public int Id { get; set; }
    public bool Alive { get; set; }
    public LinkedNode? Next { get; set; } = null;

    public bool Murder(LinkedNode x)
    {
        if (this.Equals(x))
        {
            return false;
        }

        else if (!x.Alive)
        {
            return this.Murder(x.Next);

        }
        else
        {
            x.Alive = false;
            return true;
        }
    }
}
