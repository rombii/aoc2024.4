var file = await File.ReadAllLinesAsync(Path.Join(Directory.GetCurrentDirectory(), "input.txt"));
var fileArr = new char[file.Length][];
const string expectedString = "XMAS";
for (var i = 0; i < file.Length; i++)
{
    fileArr[i] = file[i].ToCharArray();
}

int part1Answer = 0, part2Answer = 0;
int[] dx = [-1, -1, 0, 1, 1, 1, 0, -1]; //Directions up, up_right, right, down_right, down, down_left, left, up_left
int[] dy = [0, 1, 1, 1, 0, -1, -1, -1];

for (var i = 0; i < fileArr.Length; i++)
{
    for (var j = 0; j < fileArr[i].Length; j++)
    {
        if (fileArr[i][j] != expectedString[0]) continue; //Check for X

        for (var dir = 0; dir < 8; dir++)
        {
            var match = true;

            for (var k = 1; k < expectedString.Length; k++)
            {
                var ni = i + dx[dir] * k;
                var nj = j + dy[dir] * k;

                if (ni < 0 || nj < 0 || ni >= fileArr.Length || nj >= fileArr[ni].Length || fileArr[ni][nj] != expectedString[k])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                part1Answer++;
            }
        }
    }
}

for (var i = 1; i < fileArr.Length - 1; i++)
{
    for (var j = 1; j < fileArr[i].Length - 1; j++)
    {
        if (fileArr[i][j] != expectedString[2]) continue; //Check for A
        var amountOfMas = 0;
        for (var dir = 1; dir < dx.Length; dir += 2)
        {
            
            if (fileArr[i + dx[dir]][j + dy[dir]] == expectedString[1] && fileArr[i + dx[dir] * -1][j + dy[dir] * -1] == expectedString[3])
            {
                amountOfMas++;
                if (amountOfMas > 1)
                {
                    part2Answer++;
                    break;
                }
            }
        }
    }
}


Console.WriteLine($"First part: {part1Answer}");
Console.WriteLine($"Second part: {part2Answer}");
