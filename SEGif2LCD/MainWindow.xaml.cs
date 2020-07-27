using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SEGIF2LCD
{
    
    public partial class MainWindow : Window
    {

        private string baseBody = @"<?xml version=""1.0""?>
<Definitions xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <ShipBlueprints>
    <ShipBlueprint xsi:type=""MyObjectBuilder_ShipBlueprintDefinition"">
      <Id Type=""MyObjectBuilder_ShipBlueprintDefinition"" Subtype=""{name}"" />
      <DisplayName>Math0424</DisplayName>
      <CubeGrids>
        <CubeGrid>
          <SubtypeName />
          <EntityId>122728957330135645</EntityId>
          <PersistentFlags>CastShadows InScene</PersistentFlags>
          <PositionAndOrientation>
            <Position x=""13.969420336436087"" y=""18.380873227599295"" z=""-11.591902711606963"" />
            <Forward x=""-0"" y=""-0"" z=""-1"" />
            <Up x=""0"" y=""1"" z=""0"" />
            <Orientation>
              <X>0</X>
              <Y>0</Y>
              <Z>0</Z>
              <W>1</W>
            </Orientation>
          </PositionAndOrientation>
          <LocalPositionAndOrientation xsi:nil=""true"" />
          <GridSizeEnum>{size}</GridSizeEnum>
          <CubeBlocks>
            <MyObjectBuilder_CubeBlock xsi:type=""MyObjectBuilder_MyProgrammableBlock"">
              <SubtypeName>{size}ProgrammableBlock</SubtypeName>
              <EntityId>80955140279512656</EntityId>
              <Min x=""0"" y=""1"" z=""2"" />
              <BlockOrientation Forward=""Right"" Up=""Up"" />
              <Owner>144115188075855895</Owner>
              <BuiltBy>144115188075855895</BuiltBy>
              <ComponentContainer>
                <Components>
                  <ComponentData>
                    <TypeId>MyModStorageComponentBase</TypeId>
                    <Component xsi:type=""MyObjectBuilder_ModStorageComponent"">
                      <Storage>
                        <dictionary>
                          <item>
                            <Key>74de02b3-27f9-4960-b1c4-27351f2b06d1</Key>
                            <Value>{customData}</Value>
                          </item>
                        </dictionary>
                      </Storage>
                    </Component>
                  </ComponentData>
                </Components>
              </ComponentContainer>
              <ShareMode>Faction</ShareMode>
              <CustomName>{name}</CustomName>
              <ShowOnHUD>false</ShowOnHUD>
              <ShowInTerminal>{visible}</ShowInTerminal>
              <ShowInToolbarConfig>{visible}</ShowInToolbarConfig>
              <ShowInInventory>false</ShowInInventory>
              <Enabled>true</Enabled>
              <Program>bool loop = {loop}; int width = {width}; int height = {height}; string data, animateName; double currentDelay = 0, fps; int currentFrame, totalFrames, frameCharacterCount; public Program() { data = Storage; frameCharacterCount = (width * height) + height; totalFrames = data.Length / frameCharacterCount; } public void Main(string argument, UpdateType updateSource) { string[] args = argument.Split(':'); if (updateSource != UpdateType.Update1) { if (args.Length &gt;= 4 &amp;&amp; args[0].ToLower() == ""animate"") { Runtime.UpdateFrequency = UpdateFrequency.Update1; fps = double.Parse(args[1]); currentFrame = int.Parse(args[2]); animateName = args[3]; } if (args.Length &gt;= 1 &amp;&amp; args[0].ToLower() == ""stop"") { Runtime.UpdateFrequency = UpdateFrequency.None; return; } else { Echo(""Unknown argument!""); return; } } if (!loop &amp;&amp; currentFrame == totalFrames-1) { Runtime.UpdateFrequency = UpdateFrequency.None; return; } currentDelay -= 1; if (currentDelay &lt;= 0) { currentDelay = 60.0/fps; if (currentFrame &gt;= totalFrames) { currentFrame = 0; } DisplayText(data.Substring(currentFrame * frameCharacterCount, frameCharacterCount)); currentFrame++; } } public void DisplayText(string text) { List&lt;IMyTextPanel&gt; allText = new List&lt;IMyTextPanel&gt;(); GridTerminalSystem.GetBlocksOfType(allText); if (allText.Count &gt; 0) { int x = 0; for (int i = 0; i &lt; allText.Count; i++) { if (allText[i].CustomName.IndexOf(animateName) &gt; -1 &amp;&amp; data.Length &gt;= frameCharacterCount * 2) { x++; if (x &lt; 100) { allText[i].WritePublicText(text); } } } if (x &gt; 10) { currentDelay += (x - 10); } Echo(""Playing frame "" + (currentFrame + 1) + ""/"" + totalFrames + "" on "" + x + "" screens""); } } public void Save() { Storage = Storage; }</Program>
              <Storage>{data}</Storage>
              <DefaultRunArgument>{args}</DefaultRunArgument>
              <TextPanels>
                <MySerializedTextPanelData>
                  <ChangeInterval>0</ChangeInterval>
                  <Font Type=""MyObjectBuilder_FontDefinition"" Subtype=""Debug"" />
                  <FontSize>1</FontSize>
                  <ShowText>NONE</ShowText>
                  <FontColor>
                    <PackedValue>4294967295</PackedValue>
                    <X>255</X>
                    <Y>255</Y>
                    <Z>255</Z>
                    <R>255</R>
                    <G>255</G>
                    <B>255</B>
                    <A>255</A>
                  </FontColor>
                  <BackgroundColor>
                    <PackedValue>4278190080</PackedValue>
                    <X>0</X>
                    <Y>0</Y>
                    <Z>0</Z>
                    <R>0</R>
                    <G>0</G>
                    <B>0</B>
                    <A>255</A>
                  </BackgroundColor>
                  <CurrentShownTexture>0</CurrentShownTexture>
                  <SelectedScript/>
                  <TextPadding>2</TextPadding>
                  <ScriptBackgroundColor>
                    <PackedValue>4288108544</PackedValue>
                    <X>0</X>
                    <Y>88</Y>
                    <Z>151</Z>
                    <R>0</R>
                    <G>88</G>
                    <B>151</B>
                    <A>255</A>
                  </ScriptBackgroundColor>
                  <ScriptForegroundColor>
                    <PackedValue>4294962611</PackedValue>
                    <X>179</X>
                    <Y>237</Y>
                    <Z>255</Z>
                    <R>179</R>
                    <G>237</G>
                    <B>255</B>
                    <A>255</A>
                  </ScriptForegroundColor>
                  <Sprites>
                    <Length>0</Length>
                  </Sprites>
                </MySerializedTextPanelData>
                <MySerializedTextPanelData>
                  <ChangeInterval>0</ChangeInterval>
                  <Font Type=""MyObjectBuilder_FontDefinition"" Subtype=""Debug"" />
                  <FontSize>1</FontSize>
                  <ShowText>NONE</ShowText>
                  <FontColor>
                    <PackedValue>4294967295</PackedValue>
                    <X>255</X>
                    <Y>255</Y>
                    <Z>255</Z>
                    <R>255</R>
                    <G>255</G>
                    <B>255</B>
                    <A>255</A>
                  </FontColor>
                  <BackgroundColor>
                    <PackedValue>4278190080</PackedValue>
                    <X>0</X>
                    <Y>0</Y>
                    <Z>0</Z>
                    <R>0</R>
                    <G>0</G>
                    <B>0</B>
                    <A>255</A>
                  </BackgroundColor>
                  <CurrentShownTexture>0</CurrentShownTexture>
                  <SelectedScript />
                  <TextPadding>2</TextPadding>
                  <ScriptBackgroundColor>
                    <PackedValue>4288108544</PackedValue>
                    <X>0</X>
                    <Y>88</Y>
                    <Z>151</Z>
                    <R>0</R>
                    <G>88</G>
                    <B>151</B>
                    <A>255</A>
                  </ScriptBackgroundColor>
                  <ScriptForegroundColor>
                    <PackedValue>4294962611</PackedValue>
                    <X>179</X>
                    <Y>237</Y>
                    <Z>255</Z>
                    <R>179</R>
                    <G>237</G>
                    <B>255</B>
                    <A>255</A>
                  </ScriptForegroundColor>
                  <Sprites>
                    <Length>0</Length>
                  </Sprites>
                </MySerializedTextPanelData>
              </TextPanels>
            </MyObjectBuilder_CubeBlock>
          </CubeBlocks>
          <DisplayName>{name}</DisplayName>
          <DestructibleBlocks>true</DestructibleBlocks>
          <IsRespawnGrid>false</IsRespawnGrid>
          <LocalCoordSys>0</LocalCoordSys>
          <TargetingTargets />
        </CubeGrid>
      </CubeGrids>
      <EnvironmentType>None</EnvironmentType>
      <WorkshopId>0</WorkshopId>
      <OwnerSteamId>76561198161316860</OwnerSteamId>
      <Points>0</Points>
    </ShipBlueprint>
  </ShipBlueprints>
</Definitions>";

        private string multiBlockControllerBody = @"<?xml version=""1.0""?>
<Definitions xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <ShipBlueprints>
    <ShipBlueprint xsi:type=""MyObjectBuilder_ShipBlueprintDefinition"">
      <Id Type=""MyObjectBuilder_ShipBlueprintDefinition"" Subtype=""{name}"" />
      <DisplayName>Math0424</DisplayName>
      <CubeGrids>
        <CubeGrid>
          <SubtypeName />
          <EntityId>122728957330135645</EntityId>
          <PersistentFlags>CastShadows InScene</PersistentFlags>
          <PositionAndOrientation>
            <Position x=""13.969420336436087"" y=""18.380873227599295"" z=""-11.591902711606963"" />
            <Forward x=""-0"" y=""-0"" z=""-1"" />
            <Up x=""0"" y=""1"" z=""0"" />
            <Orientation>
              <X>0</X>
              <Y>0</Y>
              <Z>0</Z>
              <W>1</W>
            </Orientation>
          </PositionAndOrientation>
          <LocalPositionAndOrientation xsi:nil=""true"" />
          <GridSizeEnum>{size}</GridSizeEnum>
          <CubeBlocks>
            <MyObjectBuilder_CubeBlock xsi:type=""MyObjectBuilder_MyProgrammableBlock"">
              <SubtypeName>{size}ProgrammableBlock</SubtypeName>
              <EntityId>80955140279512656</EntityId>
              <Min x=""0"" y=""1"" z=""2"" />
              <BlockOrientation Forward=""Right"" Up=""Up"" />
              <Owner>144115188075855895</Owner>
              <BuiltBy>144115188075855895</BuiltBy>
              <ComponentContainer>
                <Components>
                  <ComponentData>
                    <TypeId>MyModStorageComponentBase</TypeId>
                    <Component xsi:type=""MyObjectBuilder_ModStorageComponent"">
                      <Storage>
                        <dictionary>
                          <item>
                            <Key>74de02b3-27f9-4960-b1c4-27351f2b06d1</Key>
                            <Value>{customData}</Value>
                          </item>
                        </dictionary>
                      </Storage>
                    </Component>
                  </ComponentData>
                </Components>
              </ComponentContainer>
              <ShareMode>Faction</ShareMode>
              <CustomName>{name}</CustomName>
              <ShowOnHUD>false</ShowOnHUD>
              <ShowInTerminal>true</ShowInTerminal>
              <ShowInToolbarConfig>true</ShowInToolbarConfig>
              <ShowInInventory>false</ShowInInventory>
              <Enabled>true</Enabled>
              <Program>bool loop = false; int chainCount = {chainCount}; int multiBlockFrameSize = {frameSize}; int totalFrames = {totalFrames}; string displayName, name; double currentFrameDelay = 0, currentBlockDelay = 0, fps; int currentBlock, currentFrame; public Program() { name = Me.CustomData; StopAll(); } public void Main(string argument, UpdateType updateSource) { string[] args = argument.Split(':'); if (updateSource != UpdateType.Update1) { if (args.Length &gt;= 4 &amp;&amp; args[0].ToLower() == ""animate"") { StopAll(); Runtime.UpdateFrequency = UpdateFrequency.Update1; fps = double.Parse(args[1]); currentFrame = int.Parse(args[2]); currentBlock = currentFrame / multiBlockFrameSize; displayName = args[3]; return; } if (args.Length &gt;= 1 &amp;&amp; args[0].ToLower() == ""stop"") { Runtime.UpdateFrequency = UpdateFrequency.None; StopAll(); return; } else { Echo(""Unknown argument!""); return; } } currentFrameDelay -= 1; if (currentFrameDelay &lt;= 0) { currentFrameDelay = (60.0/fps); if (currentFrame &gt;= totalFrames) { currentFrame = 0; StopAll(); if (!loop) { Runtime.UpdateFrequency = UpdateFrequency.None; return; } } Echo(""Playing frame "" + currentFrame + ""/"" + totalFrames + "" on part "" + currentBlock + ""/"" + chainCount); currentBlockDelay -= 1; if (currentBlockDelay &lt;= 0) { currentBlockDelay = multiBlockFrameSize; int frame = currentFrame - currentBlock * multiBlockFrameSize; List&lt;IMyProgrammableBlock&gt; allBlocks = new List&lt;IMyProgrammableBlock&gt;(); GridTerminalSystem.GetBlocksOfType(allBlocks); if (allBlocks.Count &gt; 0) { for (int i = 0; i &lt; allBlocks.Count; i++) { if (allBlocks[i] != Me &amp;&amp; allBlocks[i].CustomData.Equals(name + ""_"" + currentBlock.ToString())) { allBlocks[i].TryRun(""animate:"" + fps + "":"" + frame + "":"" + displayName); break; } } } currentBlock++; } currentFrame++; } } void StopAll() { currentBlock = 0; currentFrame = 0; currentBlockDelay = 0; List&lt;IMyProgrammableBlock&gt; allBlocks = new List&lt;IMyProgrammableBlock&gt;(); GridTerminalSystem.GetBlocksOfType(allBlocks); if (allBlocks.Count &gt; 0) { for (int i = 0; i &lt; allBlocks.Count; i++) { if (allBlocks[i] != Me &amp;&amp; allBlocks[i].CustomData.Contains(name)) { allBlocks[i].TryRun(""stop""); } } } }</Program>
              <Storage></Storage>
              <DefaultRunArgument>animate:{fps}:0:{name}</DefaultRunArgument>
              <TextPanels>
                <MySerializedTextPanelData>
                  <ChangeInterval>0</ChangeInterval>
                  <Font Type=""MyObjectBuilder_FontDefinition"" Subtype=""Debug"" />
                  <FontSize>1</FontSize>
                  <ShowText>NONE</ShowText>
                  <FontColor>
                    <PackedValue>4294967295</PackedValue>
                    <X>255</X>
                    <Y>255</Y>
                    <Z>255</Z>
                    <R>255</R>
                    <G>255</G>
                    <B>255</B>
                    <A>255</A>
                  </FontColor>
                  <BackgroundColor>
                    <PackedValue>4278190080</PackedValue>
                    <X>0</X>
                    <Y>0</Y>
                    <Z>0</Z>
                    <R>0</R>
                    <G>0</G>
                    <B>0</B>
                    <A>255</A>
                  </BackgroundColor>
                  <CurrentShownTexture>0</CurrentShownTexture>
                  <SelectedScript/>
                  <TextPadding>2</TextPadding>
                  <ScriptBackgroundColor>
                    <PackedValue>4288108544</PackedValue>
                    <X>0</X>
                    <Y>88</Y>
                    <Z>151</Z>
                    <R>0</R>
                    <G>88</G>
                    <B>151</B>
                    <A>255</A>
                  </ScriptBackgroundColor>
                  <ScriptForegroundColor>
                    <PackedValue>4294962611</PackedValue>
                    <X>179</X>
                    <Y>237</Y>
                    <Z>255</Z>
                    <R>179</R>
                    <G>237</G>
                    <B>255</B>
                    <A>255</A>
                  </ScriptForegroundColor>
                  <Sprites>
                    <Length>0</Length>
                  </Sprites>
                </MySerializedTextPanelData>
                <MySerializedTextPanelData>
                  <ChangeInterval>0</ChangeInterval>
                  <Font Type=""MyObjectBuilder_FontDefinition"" Subtype=""Debug"" />
                  <FontSize>1</FontSize>
                  <ShowText>NONE</ShowText>
                  <FontColor>
                    <PackedValue>4294967295</PackedValue>
                    <X>255</X>
                    <Y>255</Y>
                    <Z>255</Z>
                    <R>255</R>
                    <G>255</G>
                    <B>255</B>
                    <A>255</A>
                  </FontColor>
                  <BackgroundColor>
                    <PackedValue>4278190080</PackedValue>
                    <X>0</X>
                    <Y>0</Y>
                    <Z>0</Z>
                    <R>0</R>
                    <G>0</G>
                    <B>0</B>
                    <A>255</A>
                  </BackgroundColor>
                  <CurrentShownTexture>0</CurrentShownTexture>
                  <SelectedScript />
                  <TextPadding>2</TextPadding>
                  <ScriptBackgroundColor>
                    <PackedValue>4288108544</PackedValue>
                    <X>0</X>
                    <Y>88</Y>
                    <Z>151</Z>
                    <R>0</R>
                    <G>88</G>
                    <B>151</B>
                    <A>255</A>
                  </ScriptBackgroundColor>
                  <ScriptForegroundColor>
                    <PackedValue>4294962611</PackedValue>
                    <X>179</X>
                    <Y>237</Y>
                    <Z>255</Z>
                    <R>179</R>
                    <G>237</G>
                    <B>255</B>
                    <A>255</A>
                  </ScriptForegroundColor>
                  <Sprites>
                    <Length>0</Length>
                  </Sprites>
                </MySerializedTextPanelData>
              </TextPanels>
            </MyObjectBuilder_CubeBlock>
          </CubeBlocks>
          <DisplayName>{name}</DisplayName>
          <DestructibleBlocks>true</DestructibleBlocks>
          <IsRespawnGrid>false</IsRespawnGrid>
          <LocalCoordSys>0</LocalCoordSys>
          <TargetingTargets />
        </CubeGrid>
      </CubeGrids>
      <EnvironmentType>None</EnvironmentType>
      <WorkshopId>0</WorkshopId>
      <OwnerSteamId>76561198161316860</OwnerSteamId>
      <Points>0</Points>
    </ShipBlueprint>
  </ShipBlueprints>
</Definitions>";

        const int multiBlockSize = 1000;

        private FileInfo imagePath;
        private System.Drawing.Image gif;

        bool running = false;
        bool multiblock = false;

        private string size = "Large";
        bool bitrate3 = true;
        int width = 178, height = 178;
        private string imageName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateImage(string name)
        {
            imageName = name;
            if (imagePath != null && imagePath.Exists)
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath.FullName);
                ImageImg.Source = BitmapHelper.GetBitmapSource((Bitmap)image);
                gif = image;
            }
        }

        char ColorToChar(byte r, byte g, byte b)
        {
            return bitrate3 ? ColorToChar3Bit(r, g, b) : ColorToChar5Bit(r, g, b);
        }

        char ColorToChar3Bit(byte r, byte g, byte b)
        {
            return (char)((0xe100) + ((r >> 5) << 6) + ((g >> 5) << 3) + (b >> 5));
        }

        char ColorToChar5Bit(byte r, byte g, byte b)
        {
            return (char)((uint)0x3000 + ((r >> 3) << 10) + ((g >> 3) << 5) + (b >> 3));
        }

        private void Convert()
        {
            running = true;
            string blueprintPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpaceEngineers/Blueprints/local/" + Path.GetFileName(imageName);
            if (Directory.Exists(blueprintPath))
            {
                InfoLbl.Dispatcher.Invoke(() => {
                    InfoLbl.Content = "Blueprint already exists!";
                });
                running = false;
                return;
            }

            InfoLbl.Dispatcher.Invoke(() => {
                InfoLbl.Content = "Loading gif into memory...";
            });

            BitmapSource[] frames = BitmapHelper.GetFrames(gif, width, height);
            char[] frameText = new char[((width * height) + height)*frames.Length];
            char[] currentFrame = new char[(width * height) + height];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i].Freeze();
                ImageImg.Dispatcher.Invoke(() => { ImageImg.Source = frames[i]; });

                BitmapHelper.PixelColor[,] color = BitmapHelper.GetPixels(frames[i]);
                int currentPx = 0;
                for (int y = 0; y < color.GetLength(1); y++)
                {
                    InfoLbl.Dispatcher.Invoke(() => {
                        InfoLbl.Content = "Building frame " + i + "/" + frames.Length;
                    });
                    for (int x = 0; x < color.GetLength(0); x++)
                    {
                        BitmapHelper.PixelColor c = color[x, y];
                        currentFrame[currentPx] = ColorToChar(c.Red, c.Green, c.Blue);
                        currentPx++;
                    }
                    currentFrame[currentPx++] = '\n';
                }
                currentFrame.CopyTo(frameText, ((width * height) + height) * i);
            }

            PropertyItem item = gif.GetPropertyItem(0x5100);
            int fps = 1000 / ((item.Value[0] + item.Value[1] * 256) * 10);
            int dataSpace = (width * height) + height;

            if (multiblock && frames.Length > multiBlockSize)
            {
                int blockCount = (int)Math.Ceiling(frames.Length / (multiBlockSize+0.0));

                for (int x = 0; x <= blockCount; x++)
                {
                    InfoLbl.Dispatcher.Invoke(() => {
                        InfoLbl.Content = "Building block " + (x+1) + "/" + (blockCount+1);
                    });

                    string newName = imageName + "_" + x.ToString();

                    if (x == blockCount)
                    {
                        newName = imageName + "_MAIN";
                    }

                    string newDir = blueprintPath + "/" + newName;
                    Directory.CreateDirectory(newDir);
                    using (var fileStream = new FileStream(newDir + "/thumb.png", FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(frames[frames.Length/2]));
                        encoder.Save(fileStream);
                    }
                    StreamWriter text = File.CreateText(newDir + "/bp.sbc");

                    if (x == blockCount)
                    {
                        text.Write(GetProgrammableBlockController(newName, imageName, fps, frames.Length, blockCount));
                    }
                    else
                    {
                        int startIndex = x * dataSpace * multiBlockSize;
                        if (startIndex + dataSpace * multiBlockSize >= frameText.Length)
                        {
                            text.Write(GetProgrammableBlock(new string(frameText).Substring(startIndex), newName, width, height, fps, true));
                        } 
                        else
                        {
                            text.Write(GetProgrammableBlock(new string(frameText).Substring(startIndex, dataSpace * multiBlockSize), newName, width, height, fps, true));
                        }
                    }
                    text.Close();
                }
            } 
            else
            {
                Directory.CreateDirectory(blueprintPath);
                using (var fileStream = new FileStream(blueprintPath + "/thumb.png", FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(frames[frames.Length/2]));
                    encoder.Save(fileStream);
                }
                StreamWriter text = File.CreateText(blueprintPath + "/bp.sbc");
                text.Write(GetProgrammableBlock(new string(frameText), imageName, width, height, fps));
                text.Close();
            }


            InfoLbl.Dispatcher.Invoke(() => {
                InfoLbl.Content = "Finished " + frames.Length + " total frames";
            });
            running = false;
        }

        private string GetProgrammableBlock(string data, string name, int width, int height, int fps, bool multiblockMode = false)
        {
            string finalBody = baseBody.Replace("{size}", size)
                .Replace("{args}", multiblockMode ? "" : "animate:{fps}:0:{name}")
                .Replace("{name}", name)
                .Replace("{width}", width.ToString())
                .Replace("{height}", height.ToString())
                .Replace("{fps}", fps.ToString())
                .Replace("{size}", size)
                .Replace("{customData}", name)
                .Replace("{loop}", (!multiblockMode).ToString().ToLower())
                .Replace("{visible}", (!multiblockMode).ToString().ToLower())
                .Replace("{customData}", name)
                .Replace("{data}", data);
            return finalBody;
        }

        private string GetProgrammableBlockController(string name, string controlling, int fps, int totalFrames, int chainCount)
        {
            return multiBlockControllerBody.Replace("{name}", name)
                .Replace("{size}", size)
                .Replace("{customData}", controlling)
                .Replace("{totalFrames}", totalFrames.ToString())
                .Replace("{chainCount}", chainCount.ToString())
                .Replace("{frameSize}", multiBlockSize.ToString())
                .Replace("{fps}", fps.ToString());
        }

        /*private string Compress(string data, int frames)
        {
            InfoLbl.Dispatcher.Invoke(() => {
                InfoLbl.Content = "Compressing...";
            });

            string output = string.Empty;

            for (int f = 0; f < frames; f++)
            {
                string myCompressedFrame = string.Empty;
                string myFrame = data.Substring(f * ((width * height) + height), (width * height) + height);

                int count = 1;
                myCompressedFrame += myFrame[0];
                for (int i = 1; i < myFrame.Length; i++)
                {
                    char c = myFrame[i];
                    if (myFrame[i - 1].Equals(c))
                    {
                        count += 1;
                    }
                    else
                    {
                        if (count > 1)
                            myCompressedFrame += (char)(count + 64);
                        myCompressedFrame += c;
                        count = 1;
                    }
                }
                output += myCompressedFrame.Insert(0, (myCompressedFrame.Length.ToString("00000")));
            }
            return output;
        }*/

        private void UpdateText(string text)
        {
            InfoLbl.Content = text;
        }

        private void InputTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (running)
            {
                UpdateText("Cant change name while running!");
                return;
            }
            UpdateImage(((TextBox)sender).Text);
        }

        private void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (imagePath == null)
            {
                UpdateText("Invalid gif!");
                return;
            }
            if (running)
            {
                UpdateText("Already running!");
                return;
            }
            Thread thread = new Thread(new ThreadStart(Convert));
            thread.Name = "Converter";
            thread.Priority = ThreadPriority.AboveNormal;
            thread.IsBackground = true;
            thread.Start();
        }

        private void GridSizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (running)
            {
                UpdateText("Cant change grid size while running!");
                return;
            }
            size = size.Equals("Large") ? "Small" : "Large";
            GridSizeBtn.Content = size + "Grid";
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "gif files (*.gif)|*.gif",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                InputTxt.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "PB";
                imagePath = new FileInfo(openFileDialog.FileName);
                UpdateImage(Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "PB");
            }
        }

        int SizePrevIndex = 0;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (running)
            {
                UpdateText("Cant change LCD size while running!");
                LCDSize.SelectedIndex = SizePrevIndex;
                return;
            }
            SizePrevIndex = LCDSize.SelectedIndex;
            switch (LCDSize.SelectedIndex) 
            {
                case 0:
                case 2:
                case 4:
                    width = 178;
                    height = 178;
                    break;
                case 1:
                    width = 356;
                    height = 178;
                    break;
                case 3:
                    height = 107;
                    width = 178;
                    break;
            }
        }

        int BitPrevIndex = 0;
        private void FontBitRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (running)
            {
                UpdateText("Cant change Bitrate while running!");
                FontBitRate.SelectedIndex = BitPrevIndex;
                return;
            }
            if (FontBitRate.SelectedIndex == 0)
            {
                bitrate3 = true;
            } 
            else
            {
                bitrate3 = false;
            }
        }

        private void Multiblock_Checked(object sender, RoutedEventArgs e)
        {
            if (running)
            {
                UpdateText("Cant make multiblock when running!");
                Multiblock.IsChecked = !Multiblock.IsChecked;
                return;
            }
            multiblock = (bool)Multiblock.IsChecked;
        }

    }
}
