# An example project using godot-ink

This repository contains a sample Godot project providing hands on examples about how to use [godot-ink](https://github.com/paulloz/godot-ink).  

To make it work, you'll have to go through the godot-ink addon's installation process. After putting this example project in your local development directory:

* Download the [godot-ink](https://github.com/paulloz/godot-ink) project as a zip file (or clone the repository).
* Extract the godot-ink project files into your local development directory.
* Copy the addons/ folder from godot-ink into the godot-ink-example-master folder.
* Download the [inklecate](https://github.com/inkle/ink/releases) version for your operating system.
* Extract inklecate into your development directory.
* Copy ink-engine-runtime.dll and inklecate (or inklecate.exe) into the godot-ink-example-master folder.
* Optional but highly recommended: download and install [Inky](https://github.com/inkle/inky) for your operating system.

Now launch Godot and import the project.godot file from the example directory.  Godot may complain that it can't load YourStory.ink. Tell it to proceed anyway, and see the section below if the following steps don't fix things. 

With the project open, go to Project > Project Settings > General and scroll the left column down to Ink. You should see a setting for Inklecate Path. Enter the path to your inklecate installation, and in the top bar set "Type:" to "Dictionary". Close that dialog and click "Build" in the upper-right corner of the Godot window. Now go to Project > Project Settings > Plugins and enable the ink plugin.

Finally, at the bottom of the screen, click the new Ink tab that should've appeared. If YourStory.ink hasn't loaded yet, then at the right-hand end of this bottom window, you can choose to Load a file and bring it in that way.

## It didn't work!

On Linux (and possibly other operating systems), the project importation may fail. We're troubleshooting that now, but in the meantime here's a workaround. 

If the Output window at the bottom is giving you "Error importing 'res://YourStory.ink'." then start up Inky (on Linux, you'll have to do this by navigating the terminal to the directory where you've installed Inky, then typing ./Inky). 

In Inky, navigate to your godot-ink-example-master directory and open YourStory.ink. Now save it as a .json file in the same directory. Back in Godot, go to the Ink window at the bottom and load YourStory.json instead of YourStory.ink. 

If you're using this workaround, then for your actual game you'll need to edit the script in Inky, export it to .json, and load it into your game that way. You'll also need to change any occurrence of YourStory.ink to YourStory.json. 
