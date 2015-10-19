using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesBase 
{
	// ------------------------------------------------------------------------------------ //

	public static ResourcesBase resourcesBase = new ResourcesBase ();
	public static ResourcesBase getResources () {
		if (resourcesBase == null) {
			resourcesBase = new ResourcesBase ();
		}
		return resourcesBase;
	}

	public static Object load (string path) {
		return getResources().getResource(path, false);
	}

	public static Object load (string path, bool isCached) {
		return getResources().getResource(path, isCached);
	}

	public static void unload (string path) {
		getResources().unloadResource(path, null);
	}

	public static void unload (string path, Object resource) {
		getResources().unloadResource(path, resource);
	}

	public static void unloadUnused () {
		getResources().unloadUnusedResources();
	}

	// ------------------------------------------------------------------------------------ //

	private Dictionary<string, Object> cachedResources = new Dictionary<string, Object>();

	private ResourcesBase ()
	{

	}

	// ------------------------------------------------------------------------------------ //

	public Object getResource (string path, bool isCached) 
	{
		Object resource = null;
		bool load = true;

		if(cachedResources.TryGetValue(path, out resource)) {
			load = false;	//success!
		}
		
		if (load) {
			resource = Resources.Load(path);
		}
		
		if (resource != null)  {
			if (isCached && load) {
				cachedResources.Add(path, resource);
			}
		}
		else {
			SLog.logError("ResourcesBase getResource(): resource == null; path == " + path);
		}
		
		return resource;
	}

	public void unloadResource (string path, Object resource) 
	{
		if (path != null)
		{
			Object resourceCached = null;
			
			if(cachedResources.TryGetValue(path, out resourceCached)) 
			{
				cachedResources.Remove(path);
				Resources.UnloadAsset(resourceCached);
				resourceCached = null;
			}
		}

		if (resource != null) {
			Resources.UnloadAsset(resource);
			resource = null;
		}
	}

	public void unloadUnusedResources () 
	{
		Resources.UnloadUnusedAssets();
	}

	// ------------------------------------------------------------------------------------ //

}
