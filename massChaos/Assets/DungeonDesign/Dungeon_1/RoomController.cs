using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomInfo
{
    public string name;
    public int X;
    public int Y;


}

public class RoomController : MonoBehaviour
{


    public static RoomController instance;

    string currentWorldName = "Basestation";

    RoomInfo currentLoadRoomData;

    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>();

    bool isLoading = false;

    private void Awake()
    {

        instance = this;

    }
    public void LoadRoom(string name, int x, int y)
    {
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }

    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation LoadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
        while(LoadRoom.isDone == false)
        {
            yield return null;

        }
    }

    public void RegisterRoom(Room room)
    {
        room.transform.position = new Vector3(
        currentLoadRoomData.X* room.width,
        currentLoadRoomData.Y* room.height,
        0
            );

        room.X = currentLoadRoomData.X;
        room.Y = currentLoadRoomData.Y;
        room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.X + "," + room.Y;
        room.transform.parent = transform;

        //isLoadingRoom = false;
        loadedRooms.Add(room);


    }
    public bool DoesRoomExist(int x, int y)

    {
        return loadedRooms.Find(item => item.X == x && item.Y == y) != null;


    }
}