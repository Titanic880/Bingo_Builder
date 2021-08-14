{
    //JsonSerializer
    {
        Tile tile = new();
        tile.Name = "DEBUG 1.0";
        tile.Desc = "DEBUG OBJECT";
        tile.Difficulty = Diff_ENUM.Debug;
        tile.Completed = false;

        JsonSerializer serializer = new();
        serializer.NullValueHandling = NullValueHandling.Include;

        using StreamWriter sw = new("JSON.txt");
        using JsonWriter writer = new JsonTextWriter(sw);
        serializer.Serialize(writer, tile);
    }

    //JsonConvert
    {
        Tile tile = new();
        tile.Name = "DEBUG 1.0";
        tile.Desc = "DEBUG OBJECT";
        tile.Difficulty = Diff_ENUM.Debug;
        tile.Completed = false;

        string output = JsonConvert.SerializeObject(tile);
        using StreamWriter sw = new("JSON_2.txt");
        sw.Write(output);
    }
}