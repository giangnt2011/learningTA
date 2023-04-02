using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;

public class LoadSprites : MonoBehaviour
{
    public AddressableAssetGroup groupName;
    private SpriteRenderer _sprite;

    private async void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        await InitSprites("images");
        Debug.Log(AllSprites.Count);
        foreach (var _aSprite in AllSprites)
        {
            Debug.Log(_aSprite.Key);
        }

        _sprite.sprite = AllSprites["barrelBlack_top"];
        // Addressables.LoadResourceLocationsAsync("images").Completed += LoadGroupAsunc;
    }

    private async void LoadGroupAsunc(AsyncOperationHandle<IList<IResourceLocation>> obj)
    {
        // foreach (var resource in obj.Result)
        // {
        //     Debug.Log(resource);
        //     _sprite.sprite = (Sprite)resource.Data;
        // }
    }
    
    public static readonly Dictionary<string, Sprite> AllSprites = new Dictionary<string, Sprite>();
    public static async Task InitSprites(string assetLabel)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(assetLabel, typeof(Sprite)).Task;
        List<Task<Sprite>> tasks = new List<Task<Sprite>>();
        foreach (var location in locations)
        {
            tasks.Add(Addressables.LoadAssetAsync<Sprite>(location).Task);
        }
        var loadedSprites = await Task.WhenAll(tasks);
        foreach (var sprite in loadedSprites)
        {
            AllSprites.Add(sprite.name, sprite);
        }
    }
    
}
