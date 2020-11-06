
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System.Core
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly ConsoleApplication
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 29 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ..).NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 30 2C 50 72   // ,Version=v4.0,Pr
                                                                                                        6F 66 69 6C 65 3D 43 6C 69 65 6E 74 01 00 54 0E   // ofile=Client..T.
                                                                                                        14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61   // .FrameworkDispla
                                                                                                        79 4E 61 6D 65 1F 2E 4E 45 54 20 46 72 61 6D 65   // yName..NET Frame
                                                                                                        77 6F 72 6B 20 34 20 43 6C 69 65 6E 74 20 50 72   // work 4 Client Pr
                                                                                                        6F 66 69 6C 65 )                                  // ofile
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module ConsoleApplication.exe
// MVID: {DCDC14F5-C8BC-4603-98FF-B83D86607FFD}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000003    //  ILONLY 32BITREQUIRED
// Image base: 0x094F0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit GameMaster
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       42 (0x2a)
    .maxstack  2
    .locals init ([0] class IPlayer playerWhite,
             [1] class IPlayer playerBlack,
             [2] class Game gameO)
    IL_0000:  nop
    IL_0001:  ldstr      "AAAA"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ldc.i4.2
    IL_000d:  newobj     instance void HumanPlayer::.ctor(valuetype PlayerEnum)
    IL_0012:  stloc.0
    IL_0013:  ldc.i4.1
    IL_0014:  newobj     instance void HumanPlayer::.ctor(valuetype PlayerEnum)
    IL_0019:  stloc.1
    IL_001a:  ldloc.0
    IL_001b:  ldloc.1
    IL_001c:  newobj     instance void Game::.ctor(class IPlayer,
                                                   class IPlayer)
    IL_0021:  stloc.2
    IL_0022:  ldloc.2
    IL_0023:  callvirt   instance void Game::PlayRound()
    IL_0028:  nop
    IL_0029:  ret
  } // end of method GameMaster::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method GameMaster::.ctor

} // end of class GameMaster

.class public abstract auto ansi sealed beforefieldinit GameProperties
       extends [mscorlib]System.Object
{
  .field public static bool playerBlackIsHuman
  .field public static bool playerWhiteIsHuman
  .field public static int32 blackScore
  .field public static int32 whiteScore
  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldc.i4.1
    IL_0001:  stsfld     bool GameProperties::playerBlackIsHuman
    IL_0006:  ldc.i4.1
    IL_0007:  stsfld     bool GameProperties::playerWhiteIsHuman
    IL_000c:  ldc.i4.m1
    IL_000d:  stsfld     int32 GameProperties::blackScore
    IL_0012:  ldc.i4.m1
    IL_0013:  stsfld     int32 GameProperties::whiteScore
    IL_0018:  ret
  } // end of method GameProperties::.cctor

} // end of class GameProperties

.class public auto ansi beforefieldinit CPUPlayer
       extends [mscorlib]System.Object
       implements IPlayer
{
  .field private int32 '<score>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private bool '<isHuman>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private valuetype PlayerEnum '<color>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private int32[] '<currentTurnCoords>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype PlayerEnum color) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  call       instance void CPUPlayer::set_color(valuetype PlayerEnum)
    IL_000f:  nop
    IL_0010:  ldarg.0
    IL_0011:  ldc.i4.2
    IL_0012:  call       instance void CPUPlayer::set_score(int32)
    IL_0017:  nop
    IL_0018:  ldarg.0
    IL_0019:  ldc.i4.0
    IL_001a:  call       instance void CPUPlayer::set_isHuman(bool)
    IL_001f:  nop
    IL_0020:  ret
  } // end of method CPUPlayer::.ctor

  .method public hidebysig newslot specialname virtual final 
          instance int32  get_score() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 CPUPlayer::'<score>k__BackingField'
    IL_0006:  ret
  } // end of method CPUPlayer::get_score

  .method public hidebysig newslot specialname virtual final 
          instance void  set_score(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 CPUPlayer::'<score>k__BackingField'
    IL_0007:  ret
  } // end of method CPUPlayer::set_score

  .method public hidebysig newslot specialname virtual final 
          instance bool  get_isHuman() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool CPUPlayer::'<isHuman>k__BackingField'
    IL_0006:  ret
  } // end of method CPUPlayer::get_isHuman

  .method public hidebysig newslot specialname virtual final 
          instance void  set_isHuman(bool 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      bool CPUPlayer::'<isHuman>k__BackingField'
    IL_0007:  ret
  } // end of method CPUPlayer::set_isHuman

  .method public hidebysig newslot specialname virtual final 
          instance valuetype PlayerEnum  get_color() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype PlayerEnum CPUPlayer::'<color>k__BackingField'
    IL_0006:  ret
  } // end of method CPUPlayer::get_color

  .method public hidebysig newslot specialname virtual final 
          instance void  set_color(valuetype PlayerEnum 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype PlayerEnum CPUPlayer::'<color>k__BackingField'
    IL_0007:  ret
  } // end of method CPUPlayer::set_color

  .method public hidebysig newslot specialname virtual final 
          instance int32[]  get_currentTurnCoords() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32[] CPUPlayer::'<currentTurnCoords>k__BackingField'
    IL_0006:  ret
  } // end of method CPUPlayer::get_currentTurnCoords

  .method public hidebysig newslot specialname virtual final 
          instance void  set_currentTurnCoords(int32[] 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32[] CPUPlayer::'<currentTurnCoords>k__BackingField'
    IL_0007:  ret
  } // end of method CPUPlayer::set_currentTurnCoords

  .method public hidebysig newslot virtual final 
          instance void  UpdateMoves(int32[][] validMoves) cil managed
  {
    // Code size       48 (0x30)
    .maxstack  6
    .locals init ([0] class [mscorlib]System.Random random,
             [1] int32 move)
    IL_0000:  nop
    IL_0001:  newobj     instance void [mscorlib]System.Random::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  ldarg.1
    IL_000a:  ldlen
    IL_000b:  conv.i4
    IL_000c:  callvirt   instance int32 [mscorlib]System.Random::Next(int32,
                                                                      int32)
    IL_0011:  stloc.1
    IL_0012:  ldarg.0
    IL_0013:  ldc.i4.2
    IL_0014:  newarr     [mscorlib]System.Int32
    IL_0019:  dup
    IL_001a:  ldc.i4.0
    IL_001b:  ldarg.1
    IL_001c:  ldloc.1
    IL_001d:  ldelem.ref
    IL_001e:  ldc.i4.0
    IL_001f:  ldelem.i4
    IL_0020:  stelem.i4
    IL_0021:  dup
    IL_0022:  ldc.i4.1
    IL_0023:  ldarg.1
    IL_0024:  ldloc.1
    IL_0025:  ldelem.ref
    IL_0026:  ldc.i4.1
    IL_0027:  ldelem.i4
    IL_0028:  stelem.i4
    IL_0029:  call       instance void CPUPlayer::set_currentTurnCoords(int32[])
    IL_002e:  nop
    IL_002f:  ret
  } // end of method CPUPlayer::UpdateMoves

  .property instance int32 score()
  {
    .get instance int32 CPUPlayer::get_score()
    .set instance void CPUPlayer::set_score(int32)
  } // end of property CPUPlayer::score
  .property instance bool isHuman()
  {
    .get instance bool CPUPlayer::get_isHuman()
    .set instance void CPUPlayer::set_isHuman(bool)
  } // end of property CPUPlayer::isHuman
  .property instance valuetype PlayerEnum
          color()
  {
    .get instance valuetype PlayerEnum CPUPlayer::get_color()
    .set instance void CPUPlayer::set_color(valuetype PlayerEnum)
  } // end of property CPUPlayer::color
  .property instance int32[] currentTurnCoords()
  {
    .get instance int32[] CPUPlayer::get_currentTurnCoords()
    .set instance void CPUPlayer::set_currentTurnCoords(int32[])
  } // end of property CPUPlayer::currentTurnCoords
} // end of class CPUPlayer

.class public auto ansi beforefieldinit HumanPlayer
       extends [mscorlib]System.Object
       implements IPlayer
{
  .field private bool '<isHuman>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private int32 '<score>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private valuetype PlayerEnum '<color>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private int32[] '<currentTurnCoords>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype PlayerEnum color) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  call       instance void HumanPlayer::set_color(valuetype PlayerEnum)
    IL_000f:  nop
    IL_0010:  ldarg.0
    IL_0011:  ldc.i4.2
    IL_0012:  call       instance void HumanPlayer::set_score(int32)
    IL_0017:  nop
    IL_0018:  ldarg.0
    IL_0019:  ldc.i4.1
    IL_001a:  call       instance void HumanPlayer::set_isHuman(bool)
    IL_001f:  nop
    IL_0020:  ret
  } // end of method HumanPlayer::.ctor

  .method public hidebysig newslot specialname virtual final 
          instance bool  get_isHuman() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool HumanPlayer::'<isHuman>k__BackingField'
    IL_0006:  ret
  } // end of method HumanPlayer::get_isHuman

  .method public hidebysig newslot specialname virtual final 
          instance void  set_isHuman(bool 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      bool HumanPlayer::'<isHuman>k__BackingField'
    IL_0007:  ret
  } // end of method HumanPlayer::set_isHuman

  .method public hidebysig newslot specialname virtual final 
          instance int32  get_score() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 HumanPlayer::'<score>k__BackingField'
    IL_0006:  ret
  } // end of method HumanPlayer::get_score

  .method public hidebysig newslot specialname virtual final 
          instance void  set_score(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 HumanPlayer::'<score>k__BackingField'
    IL_0007:  ret
  } // end of method HumanPlayer::set_score

  .method public hidebysig newslot specialname virtual final 
          instance valuetype PlayerEnum  get_color() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype PlayerEnum HumanPlayer::'<color>k__BackingField'
    IL_0006:  ret
  } // end of method HumanPlayer::get_color

  .method public hidebysig newslot specialname virtual final 
          instance void  set_color(valuetype PlayerEnum 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype PlayerEnum HumanPlayer::'<color>k__BackingField'
    IL_0007:  ret
  } // end of method HumanPlayer::set_color

  .method public hidebysig newslot specialname virtual final 
          instance int32[]  get_currentTurnCoords() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32[] HumanPlayer::'<currentTurnCoords>k__BackingField'
    IL_0006:  ret
  } // end of method HumanPlayer::get_currentTurnCoords

  .method public hidebysig newslot specialname virtual final 
          instance void  set_currentTurnCoords(int32[] 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32[] HumanPlayer::'<currentTurnCoords>k__BackingField'
    IL_0007:  ret
  } // end of method HumanPlayer::set_currentTurnCoords

  .method public hidebysig newslot virtual final 
          instance void  UpdateMoves(int32[][] possibleMoveCoords) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.1
    IL_0003:  ldc.i4.0
    IL_0004:  ldelem.ref
    IL_0005:  call       instance void HumanPlayer::set_currentTurnCoords(int32[])
    IL_000a:  nop
    IL_000b:  ret
  } // end of method HumanPlayer::UpdateMoves

  .property instance bool isHuman()
  {
    .get instance bool HumanPlayer::get_isHuman()
    .set instance void HumanPlayer::set_isHuman(bool)
  } // end of property HumanPlayer::isHuman
  .property instance int32 score()
  {
    .get instance int32 HumanPlayer::get_score()
    .set instance void HumanPlayer::set_score(int32)
  } // end of property HumanPlayer::score
  .property instance valuetype PlayerEnum
          color()
  {
    .get instance valuetype PlayerEnum HumanPlayer::get_color()
    .set instance void HumanPlayer::set_color(valuetype PlayerEnum)
  } // end of property HumanPlayer::color
  .property instance int32[] currentTurnCoords()
  {
    .get instance int32[] HumanPlayer::get_currentTurnCoords()
    .set instance void HumanPlayer::set_currentTurnCoords(int32[])
  } // end of property HumanPlayer::currentTurnCoords
} // end of class HumanPlayer

.class public auto ansi beforefieldinit Board
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public BoardUpdateEvent
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method BoardUpdateEvent::.ctor

    .method public hidebysig newslot virtual 
            instance void  Invoke() runtime managed
    {
    } // end of method BoardUpdateEvent::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method BoardUpdateEvent::BeginInvoke

    .method public hidebysig newslot virtual 
            instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method BoardUpdateEvent::EndInvoke

  } // end of class BoardUpdateEvent

  .field public int32 boardLength
  .field public class BoardSquare[0...,0...] board
  .field private static class Board/BoardUpdateEvent boardUpdateEvent
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname static 
          void  add_boardUpdateEvent(class Board/BoardUpdateEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Board/BoardUpdateEvent V_0,
             class Board/BoardUpdateEvent V_1,
             class Board/BoardUpdateEvent V_2)
    IL_0000:  ldsfld     class Board/BoardUpdateEvent Board::boardUpdateEvent
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_000f:  castclass  Board/BoardUpdateEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Board/BoardUpdateEvent Board::boardUpdateEvent
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Board/BoardUpdateEvent>(!!0&,
                                                                                                                   !!0,
                                                                                                                   !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Board::add_boardUpdateEvent

  .method public hidebysig specialname static 
          void  remove_boardUpdateEvent(class Board/BoardUpdateEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Board/BoardUpdateEvent V_0,
             class Board/BoardUpdateEvent V_1,
             class Board/BoardUpdateEvent V_2)
    IL_0000:  ldsfld     class Board/BoardUpdateEvent Board::boardUpdateEvent
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_000f:  castclass  Board/BoardUpdateEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Board/BoardUpdateEvent Board::boardUpdateEvent
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Board/BoardUpdateEvent>(!!0&,
                                                                                                                   !!0,
                                                                                                                   !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Board::remove_boardUpdateEvent

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       39 (0x27)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.8
    IL_0002:  stfld      int32 Board::boardLength
    IL_0007:  ldarg.0
    IL_0008:  call       instance void [mscorlib]System.Object::.ctor()
    IL_000d:  nop
    IL_000e:  nop
    IL_000f:  ldarg.0
    IL_0010:  ldarg.0
    IL_0011:  ldfld      int32 Board::boardLength
    IL_0016:  ldarg.0
    IL_0017:  ldfld      int32 Board::boardLength
    IL_001c:  newobj     instance void class BoardSquare[0...,0...]::.ctor(int32,
                                                                           int32)
    IL_0021:  stfld      class BoardSquare[0...,0...] Board::board
    IL_0026:  ret
  } // end of method Board::.ctor

  .method public hidebysig instance void 
          InitBoard() cil managed
  {
    // Code size       153 (0x99)
    .maxstack  4
    .locals init ([0] int32 i,
             [1] int32 j,
             [2] bool V_2,
             [3] bool V_3)
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  stloc.0
    IL_0003:  br.s       IL_0034

    IL_0005:  nop
    IL_0006:  ldc.i4.0
    IL_0007:  stloc.1
    IL_0008:  br.s       IL_0022

    IL_000a:  nop
    IL_000b:  ldarg.0
    IL_000c:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0011:  ldloc.0
    IL_0012:  ldloc.1
    IL_0013:  newobj     instance void BoardSquare::.ctor()
    IL_0018:  call       instance void class BoardSquare[0...,0...]::Set(int32,
                                                                         int32,
                                                                         class BoardSquare)
    IL_001d:  nop
    IL_001e:  ldloc.1
    IL_001f:  ldc.i4.1
    IL_0020:  add
    IL_0021:  stloc.1
    IL_0022:  ldloc.1
    IL_0023:  ldarg.0
    IL_0024:  ldfld      int32 Board::boardLength
    IL_0029:  clt
    IL_002b:  stloc.2
    IL_002c:  ldloc.2
    IL_002d:  brtrue.s   IL_000a

    IL_002f:  nop
    IL_0030:  ldloc.0
    IL_0031:  ldc.i4.1
    IL_0032:  add
    IL_0033:  stloc.0
    IL_0034:  ldloc.0
    IL_0035:  ldarg.0
    IL_0036:  ldfld      int32 Board::boardLength
    IL_003b:  clt
    IL_003d:  stloc.3
    IL_003e:  ldloc.3
    IL_003f:  brtrue.s   IL_0005

    IL_0041:  ldarg.0
    IL_0042:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0047:  ldc.i4.3
    IL_0048:  ldc.i4.3
    IL_0049:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_004e:  ldc.i4.2
    IL_004f:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0054:  ldarg.0
    IL_0055:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_005a:  ldc.i4.4
    IL_005b:  ldc.i4.4
    IL_005c:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0061:  ldc.i4.2
    IL_0062:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0067:  ldarg.0
    IL_0068:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_006d:  ldc.i4.3
    IL_006e:  ldc.i4.4
    IL_006f:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0074:  ldc.i4.1
    IL_0075:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_007a:  ldarg.0
    IL_007b:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0080:  ldc.i4.4
    IL_0081:  ldc.i4.3
    IL_0082:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0087:  ldc.i4.1
    IL_0088:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_008d:  ldsfld     class Board/BoardUpdateEvent Board::boardUpdateEvent
    IL_0092:  callvirt   instance void Board/BoardUpdateEvent::Invoke()
    IL_0097:  nop
    IL_0098:  ret
  } // end of method Board::InitBoard

  .method public hidebysig instance int32[][] 
          GetValidMovesList(class IPlayer currPlayer) cil managed
  {
    // Code size       139 (0x8b)
    .maxstack  6
    .locals init ([0] valuetype PlayerEnum currentPlayer,
             [1] class [System.Core]System.Collections.Generic.HashSet`1<int32[]> validMovesList,
             [2] int32 i,
             [3] int32 j,
             [4] bool V_4,
             [5] bool V_5,
             [6] bool V_6,
             [7] int32[][] V_7)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance valuetype PlayerEnum IPlayer::get_color()
    IL_0007:  stloc.0
    IL_0008:  newobj     instance void class [System.Core]System.Collections.Generic.HashSet`1<int32[]>::.ctor()
    IL_000d:  stloc.1
    IL_000e:  ldc.i4.0
    IL_000f:  stloc.2
    IL_0010:  br.s       IL_006f

    IL_0012:  nop
    IL_0013:  ldc.i4.0
    IL_0014:  stloc.3
    IL_0015:  br.s       IL_005b

    IL_0017:  nop
    IL_0018:  ldarg.0
    IL_0019:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_001e:  ldloc.2
    IL_001f:  ldloc.3
    IL_0020:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0025:  ldfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_002a:  ldloc.0
    IL_002b:  ceq
    IL_002d:  stloc.s    V_4
    IL_002f:  ldloc.s    V_4
    IL_0031:  brfalse.s  IL_0056

    IL_0033:  nop
    IL_0034:  ldloc.1
    IL_0035:  ldarg.0
    IL_0036:  ldc.i4.2
    IL_0037:  newarr     [mscorlib]System.Int32
    IL_003c:  dup
    IL_003d:  ldc.i4.0
    IL_003e:  ldloc.3
    IL_003f:  stelem.i4
    IL_0040:  dup
    IL_0041:  ldc.i4.1
    IL_0042:  ldloc.2
    IL_0043:  stelem.i4
    IL_0044:  ldloc.0
    IL_0045:  call       instance class [System.Core]System.Collections.Generic.HashSet`1<int32[]> Board::getValidMovesForAPiece(int32[],
                                                                                                                                 valuetype PlayerEnum)
    IL_004a:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Concat<int32[]>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                            class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_004f:  newobj     instance void class [System.Core]System.Collections.Generic.HashSet`1<int32[]>::.ctor(class [mscorlib]System.Collections.Generic.IEnumerable`1<!0>)
    IL_0054:  stloc.1
    IL_0055:  nop
    IL_0056:  nop
    IL_0057:  ldloc.3
    IL_0058:  ldc.i4.1
    IL_0059:  add
    IL_005a:  stloc.3
    IL_005b:  ldloc.3
    IL_005c:  ldarg.0
    IL_005d:  ldfld      int32 Board::boardLength
    IL_0062:  clt
    IL_0064:  stloc.s    V_5
    IL_0066:  ldloc.s    V_5
    IL_0068:  brtrue.s   IL_0017

    IL_006a:  nop
    IL_006b:  ldloc.2
    IL_006c:  ldc.i4.1
    IL_006d:  add
    IL_006e:  stloc.2
    IL_006f:  ldloc.2
    IL_0070:  ldarg.0
    IL_0071:  ldfld      int32 Board::boardLength
    IL_0076:  clt
    IL_0078:  stloc.s    V_6
    IL_007a:  ldloc.s    V_6
    IL_007c:  brtrue.s   IL_0012

    IL_007e:  ldloc.1
    IL_007f:  call       !!0[] [System.Core]System.Linq.Enumerable::ToArray<int32[]>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_0084:  stloc.s    V_7
    IL_0086:  br.s       IL_0088

    IL_0088:  ldloc.s    V_7
    IL_008a:  ret
  } // end of method Board::GetValidMovesList

  .method private hidebysig instance class [System.Core]System.Collections.Generic.HashSet`1<int32[]> 
          getValidMovesForAPiece(int32[] boardSquareCoordinates,
                                 valuetype PlayerEnum currentPlayer) cil managed
  {
    // Code size       225 (0xe1)
    .maxstack  6
    .locals init ([0] int32[][] dirs,
             [1] class [System.Core]System.Collections.Generic.HashSet`1<int32[]> validMovesList,
             [2] int32[] 'array',
             [3] int32 i,
             [4] bool V_4,
             [5] bool V_5,
             [6] class [System.Core]System.Collections.Generic.HashSet`1<int32[]> V_6)
    IL_0000:  nop
    IL_0001:  ldc.i4.8
    IL_0002:  newarr     int32[]
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  ldc.i4.0
    IL_000a:  ldc.i4.2
    IL_000b:  newarr     [mscorlib]System.Int32
    IL_0010:  dup
    IL_0011:  ldc.i4.0
    IL_0012:  ldc.i4.m1
    IL_0013:  stelem.i4
    IL_0014:  dup
    IL_0015:  ldc.i4.1
    IL_0016:  ldc.i4.m1
    IL_0017:  stelem.i4
    IL_0018:  stelem.ref
    IL_0019:  ldloc.0
    IL_001a:  ldc.i4.1
    IL_001b:  ldc.i4.2
    IL_001c:  newarr     [mscorlib]System.Int32
    IL_0021:  dup
    IL_0022:  ldc.i4.0
    IL_0023:  ldc.i4.m1
    IL_0024:  stelem.i4
    IL_0025:  stelem.ref
    IL_0026:  ldloc.0
    IL_0027:  ldc.i4.2
    IL_0028:  ldc.i4.2
    IL_0029:  newarr     [mscorlib]System.Int32
    IL_002e:  dup
    IL_002f:  ldc.i4.0
    IL_0030:  ldc.i4.1
    IL_0031:  stelem.i4
    IL_0032:  dup
    IL_0033:  ldc.i4.1
    IL_0034:  ldc.i4.m1
    IL_0035:  stelem.i4
    IL_0036:  stelem.ref
    IL_0037:  ldloc.0
    IL_0038:  ldc.i4.3
    IL_0039:  ldc.i4.2
    IL_003a:  newarr     [mscorlib]System.Int32
    IL_003f:  dup
    IL_0040:  ldc.i4.1
    IL_0041:  ldc.i4.1
    IL_0042:  stelem.i4
    IL_0043:  stelem.ref
    IL_0044:  ldloc.0
    IL_0045:  ldc.i4.4
    IL_0046:  ldc.i4.2
    IL_0047:  newarr     [mscorlib]System.Int32
    IL_004c:  dup
    IL_004d:  ldc.i4.0
    IL_004e:  ldc.i4.1
    IL_004f:  stelem.i4
    IL_0050:  dup
    IL_0051:  ldc.i4.1
    IL_0052:  ldc.i4.1
    IL_0053:  stelem.i4
    IL_0054:  stelem.ref
    IL_0055:  ldloc.0
    IL_0056:  ldc.i4.5
    IL_0057:  ldc.i4.2
    IL_0058:  newarr     [mscorlib]System.Int32
    IL_005d:  dup
    IL_005e:  ldc.i4.0
    IL_005f:  ldc.i4.1
    IL_0060:  stelem.i4
    IL_0061:  stelem.ref
    IL_0062:  ldloc.0
    IL_0063:  ldc.i4.6
    IL_0064:  ldc.i4.2
    IL_0065:  newarr     [mscorlib]System.Int32
    IL_006a:  dup
    IL_006b:  ldc.i4.0
    IL_006c:  ldc.i4.m1
    IL_006d:  stelem.i4
    IL_006e:  dup
    IL_006f:  ldc.i4.1
    IL_0070:  ldc.i4.1
    IL_0071:  stelem.i4
    IL_0072:  stelem.ref
    IL_0073:  ldloc.0
    IL_0074:  ldc.i4.7
    IL_0075:  ldc.i4.2
    IL_0076:  newarr     [mscorlib]System.Int32
    IL_007b:  dup
    IL_007c:  ldc.i4.1
    IL_007d:  ldc.i4.m1
    IL_007e:  stelem.i4
    IL_007f:  stelem.ref
    IL_0080:  newobj     instance void class [System.Core]System.Collections.Generic.HashSet`1<int32[]>::.ctor()
    IL_0085:  stloc.1
    IL_0086:  ldc.i4.0
    IL_0087:  stloc.3
    IL_0088:  br.s       IL_00cd

    IL_008a:  nop
    IL_008b:  ldarg.0
    IL_008c:  ldarg.1
    IL_008d:  ldloc.0
    IL_008e:  ldloc.3
    IL_008f:  ldelem.ref
    IL_0090:  ldarg.2
    IL_0091:  call       instance int32[] Board::GetSuccesfulMoveInDirection(int32[],
                                                                             int32[],
                                                                             valuetype PlayerEnum)
    IL_0096:  stloc.2
    IL_0097:  ldloc.2
    IL_0098:  ldc.i4.0
    IL_0099:  ldelem.i4
    IL_009a:  ldc.i4.1
    IL_009b:  ceq
    IL_009d:  stloc.s    V_4
    IL_009f:  ldloc.s    V_4
    IL_00a1:  brfalse.s  IL_00c8

    IL_00a3:  ldloc.1
    IL_00a4:  ldc.i4.4
    IL_00a5:  newarr     [mscorlib]System.Int32
    IL_00aa:  dup
    IL_00ab:  ldc.i4.0
    IL_00ac:  ldloc.2
    IL_00ad:  ldc.i4.1
    IL_00ae:  ldelem.i4
    IL_00af:  stelem.i4
    IL_00b0:  dup
    IL_00b1:  ldc.i4.1
    IL_00b2:  ldloc.2
    IL_00b3:  ldc.i4.2
    IL_00b4:  ldelem.i4
    IL_00b5:  stelem.i4
    IL_00b6:  dup
    IL_00b7:  ldc.i4.2
    IL_00b8:  ldloc.2
    IL_00b9:  ldc.i4.3
    IL_00ba:  ldelem.i4
    IL_00bb:  stelem.i4
    IL_00bc:  dup
    IL_00bd:  ldc.i4.3
    IL_00be:  ldloc.2
    IL_00bf:  ldc.i4.4
    IL_00c0:  ldelem.i4
    IL_00c1:  stelem.i4
    IL_00c2:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<int32[]>::Add(!0)
    IL_00c7:  pop
    IL_00c8:  nop
    IL_00c9:  ldloc.3
    IL_00ca:  ldc.i4.1
    IL_00cb:  add
    IL_00cc:  stloc.3
    IL_00cd:  ldloc.3
    IL_00ce:  ldloc.0
    IL_00cf:  ldlen
    IL_00d0:  conv.i4
    IL_00d1:  clt
    IL_00d3:  stloc.s    V_5
    IL_00d5:  ldloc.s    V_5
    IL_00d7:  brtrue.s   IL_008a

    IL_00d9:  ldloc.1
    IL_00da:  stloc.s    V_6
    IL_00dc:  br.s       IL_00de

    IL_00de:  ldloc.s    V_6
    IL_00e0:  ret
  } // end of method Board::getValidMovesForAPiece

  .method public hidebysig instance int32[] 
          GetSuccesfulMoveInDirection(int32[] boardSquareCoordinates,
                                      int32[] direction,
                                      valuetype PlayerEnum currentPlayer) cil managed
  {
    // Code size       268 (0x10c)
    .maxstack  5
    .locals init ([0] int32 hasEnemies,
             [1] bool reachedNullOrAlly,
             [2] int32 x,
             [3] int32 y,
             [4] int32[] tempCoords,
             [5] bool V_5,
             [6] bool V_6,
             [7] bool V_7,
             [8] bool V_8,
             [9] int32[] V_9)
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  stloc.0
    IL_0003:  ldc.i4.0
    IL_0004:  stloc.1
    IL_0005:  ldarg.2
    IL_0006:  ldc.i4.0
    IL_0007:  ldelem.i4
    IL_0008:  stloc.2
    IL_0009:  ldarg.2
    IL_000a:  ldc.i4.1
    IL_000b:  ldelem.i4
    IL_000c:  stloc.3
    IL_000d:  ldarg.1
    IL_000e:  callvirt   instance object [mscorlib]System.Array::Clone()
    IL_0013:  castclass  int32[]
    IL_0018:  stloc.s    tempCoords
    IL_001a:  br         IL_00d8

    IL_001f:  nop
    IL_0020:  ldloc.s    tempCoords
    IL_0022:  ldc.i4.1
    IL_0023:  ldelema    [mscorlib]System.Int32
    IL_0028:  dup
    IL_0029:  ldind.i4
    IL_002a:  ldloc.2
    IL_002b:  add
    IL_002c:  stind.i4
    IL_002d:  ldloc.s    tempCoords
    IL_002f:  ldc.i4.0
    IL_0030:  ldelema    [mscorlib]System.Int32
    IL_0035:  dup
    IL_0036:  ldind.i4
    IL_0037:  ldloc.3
    IL_0038:  add
    IL_0039:  stind.i4
    IL_003a:  ldarg.0
    IL_003b:  ldloc.s    tempCoords
    IL_003d:  ldc.i4.0
    IL_003e:  ldelem.i4
    IL_003f:  call       instance bool Board::IsInRange(int32)
    IL_0044:  brfalse.s  IL_0052

    IL_0046:  ldarg.0
    IL_0047:  ldloc.s    tempCoords
    IL_0049:  ldc.i4.1
    IL_004a:  ldelem.i4
    IL_004b:  call       instance bool Board::IsInRange(int32)
    IL_0050:  br.s       IL_0053

    IL_0052:  ldc.i4.0
    IL_0053:  stloc.s    V_5
    IL_0055:  ldloc.s    V_5
    IL_0057:  brfalse.s  IL_00d1

    IL_0059:  nop
    IL_005a:  ldarg.0
    IL_005b:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0060:  ldloc.s    tempCoords
    IL_0062:  ldc.i4.1
    IL_0063:  ldelem.i4
    IL_0064:  ldloc.s    tempCoords
    IL_0066:  ldc.i4.0
    IL_0067:  ldelem.i4
    IL_0068:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_006d:  ldfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0072:  brfalse.s  IL_0091

    IL_0074:  ldarg.0
    IL_0075:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_007a:  ldloc.s    tempCoords
    IL_007c:  ldc.i4.1
    IL_007d:  ldelem.i4
    IL_007e:  ldloc.s    tempCoords
    IL_0080:  ldc.i4.0
    IL_0081:  ldelem.i4
    IL_0082:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0087:  ldfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_008c:  ldarg.3
    IL_008d:  ceq
    IL_008f:  br.s       IL_0092

    IL_0091:  ldc.i4.1
    IL_0092:  stloc.s    V_6
    IL_0094:  ldloc.s    V_6
    IL_0096:  brfalse.s  IL_00ca

    IL_0098:  nop
    IL_0099:  ldloc.0
    IL_009a:  ldc.i4.1
    IL_009b:  bne.un.s   IL_00ba

    IL_009d:  ldarg.0
    IL_009e:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_00a3:  ldloc.s    tempCoords
    IL_00a5:  ldc.i4.1
    IL_00a6:  ldelem.i4
    IL_00a7:  ldloc.s    tempCoords
    IL_00a9:  ldc.i4.0
    IL_00aa:  ldelem.i4
    IL_00ab:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_00b0:  ldfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_00b5:  ldarg.3
    IL_00b6:  ceq
    IL_00b8:  br.s       IL_00bb

    IL_00ba:  ldc.i4.0
    IL_00bb:  stloc.s    V_7
    IL_00bd:  ldloc.s    V_7
    IL_00bf:  brfalse.s  IL_00c5

    IL_00c1:  nop
    IL_00c2:  ldc.i4.0
    IL_00c3:  stloc.0
    IL_00c4:  nop
    IL_00c5:  ldc.i4.1
    IL_00c6:  stloc.1
    IL_00c7:  nop
    IL_00c8:  br.s       IL_00ce

    IL_00ca:  nop
    IL_00cb:  ldc.i4.1
    IL_00cc:  stloc.0
    IL_00cd:  nop
    IL_00ce:  nop
    IL_00cf:  br.s       IL_00d7

    IL_00d1:  nop
    IL_00d2:  ldc.i4.0
    IL_00d3:  stloc.0
    IL_00d4:  ldc.i4.1
    IL_00d5:  stloc.1
    IL_00d6:  nop
    IL_00d7:  nop
    IL_00d8:  ldloc.1
    IL_00d9:  ldc.i4.0
    IL_00da:  ceq
    IL_00dc:  stloc.s    V_8
    IL_00de:  ldloc.s    V_8
    IL_00e0:  brtrue     IL_001f

    IL_00e5:  ldc.i4.5
    IL_00e6:  newarr     [mscorlib]System.Int32
    IL_00eb:  dup
    IL_00ec:  ldc.i4.0
    IL_00ed:  ldloc.0
    IL_00ee:  stelem.i4
    IL_00ef:  dup
    IL_00f0:  ldc.i4.1
    IL_00f1:  ldloc.s    tempCoords
    IL_00f3:  ldc.i4.0
    IL_00f4:  ldelem.i4
    IL_00f5:  stelem.i4
    IL_00f6:  dup
    IL_00f7:  ldc.i4.2
    IL_00f8:  ldloc.s    tempCoords
    IL_00fa:  ldc.i4.1
    IL_00fb:  ldelem.i4
    IL_00fc:  stelem.i4
    IL_00fd:  dup
    IL_00fe:  ldc.i4.3
    IL_00ff:  ldloc.2
    IL_0100:  stelem.i4
    IL_0101:  dup
    IL_0102:  ldc.i4.4
    IL_0103:  ldloc.3
    IL_0104:  stelem.i4
    IL_0105:  stloc.s    V_9
    IL_0107:  br.s       IL_0109

    IL_0109:  ldloc.s    V_9
    IL_010b:  ret
  } // end of method Board::GetSuccesfulMoveInDirection

  .method public hidebysig instance bool 
          IsInRange(int32 'value') cil managed
  {
    // Code size       25 (0x19)
    .maxstack  2
    .locals init ([0] bool V_0)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  ldarg.0
    IL_0003:  ldfld      int32 Board::boardLength
    IL_0008:  bge.s      IL_0013

    IL_000a:  ldarg.1
    IL_000b:  ldc.i4.0
    IL_000c:  clt
    IL_000e:  ldc.i4.0
    IL_000f:  ceq
    IL_0011:  br.s       IL_0014

    IL_0013:  ldc.i4.0
    IL_0014:  stloc.0
    IL_0015:  br.s       IL_0017

    IL_0017:  ldloc.0
    IL_0018:  ret
  } // end of method Board::IsInRange

  .method public hidebysig instance int32 
          UpdateBeatPieces(class [mscorlib]System.Collections.Generic.List`1<int32[]> validMoves,
                           class IPlayer currentPlayer) cil managed
  {
    // Code size       141 (0x8d)
    .maxstack  8
    .locals init ([0] valuetype PlayerEnum currentTurn,
             [1] int32 changedPieces,
             [2] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32[]> V_2,
             [3] int32[] XYDirection,
             [4] bool V_4,
             [5] int32 V_5)
    IL_0000:  nop
    IL_0001:  ldarg.2
    IL_0002:  callvirt   instance valuetype PlayerEnum IPlayer::get_color()
    IL_0007:  stloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.1
    IL_000a:  nop
    IL_000b:  ldarg.1
    IL_000c:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<int32[]>::GetEnumerator()
    IL_0011:  stloc.2
    .try
    {
      IL_0012:  br.s       IL_005a

      IL_0014:  ldloca.s   V_2
      IL_0016:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32[]>::get_Current()
      IL_001b:  stloc.3
      IL_001c:  nop
      IL_001d:  ldloc.0
      IL_001e:  ldc.i4.1
      IL_001f:  ceq
      IL_0021:  stloc.s    V_4
      IL_0023:  ldloc.s    V_4
      IL_0025:  brfalse.s  IL_0042

      IL_0027:  nop
      IL_0028:  ldarg.0
      IL_0029:  ldloc.3
      IL_002a:  ldc.i4.0
      IL_002b:  ldelem.i4
      IL_002c:  ldloc.3
      IL_002d:  ldc.i4.1
      IL_002e:  ldelem.i4
      IL_002f:  ldloc.3
      IL_0030:  ldc.i4.2
      IL_0031:  ldelem.i4
      IL_0032:  ldloc.3
      IL_0033:  ldc.i4.3
      IL_0034:  ldelem.i4
      IL_0035:  ldloc.0
      IL_0036:  ldc.i4.2
      IL_0037:  ldloca.s   changedPieces
      IL_0039:  call       instance void Board::ChangePieces(int32,
                                                             int32,
                                                             int32,
                                                             int32,
                                                             valuetype PlayerEnum,
                                                             valuetype PlayerEnum,
                                                             int32&)
      IL_003e:  nop
      IL_003f:  nop
      IL_0040:  br.s       IL_0059

      IL_0042:  ldarg.0
      IL_0043:  ldloc.3
      IL_0044:  ldc.i4.0
      IL_0045:  ldelem.i4
      IL_0046:  ldloc.3
      IL_0047:  ldc.i4.1
      IL_0048:  ldelem.i4
      IL_0049:  ldloc.3
      IL_004a:  ldc.i4.2
      IL_004b:  ldelem.i4
      IL_004c:  ldloc.3
      IL_004d:  ldc.i4.3
      IL_004e:  ldelem.i4
      IL_004f:  ldloc.0
      IL_0050:  ldc.i4.1
      IL_0051:  ldloca.s   changedPieces
      IL_0053:  call       instance void Board::ChangePieces(int32,
                                                             int32,
                                                             int32,
                                                             int32,
                                                             valuetype PlayerEnum,
                                                             valuetype PlayerEnum,
                                                             int32&)
      IL_0058:  nop
      IL_0059:  nop
      IL_005a:  ldloca.s   V_2
      IL_005c:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32[]>::MoveNext()
      IL_0061:  brtrue.s   IL_0014

      IL_0063:  leave.s    IL_0074

    }  // end .try
    finally
    {
      IL_0065:  ldloca.s   V_2
      IL_0067:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32[]>
      IL_006d:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0072:  nop
      IL_0073:  endfinally
    }  // end handler
    IL_0074:  ldsfld     class Board/BoardUpdateEvent Board::boardUpdateEvent
    IL_0079:  dup
    IL_007a:  brtrue.s   IL_007f

    IL_007c:  pop
    IL_007d:  br.s       IL_0085

    IL_007f:  callvirt   instance void Board/BoardUpdateEvent::Invoke()
    IL_0084:  nop
    IL_0085:  ldloc.1
    IL_0086:  stloc.s    V_5
    IL_0088:  br.s       IL_008a

    IL_008a:  ldloc.s    V_5
    IL_008c:  ret
  } // end of method Board::UpdateBeatPieces

  .method public hidebysig instance void 
          ChangePieces(int32 coordX,
                       int32 coordY,
                       int32 x,
                       int32 y,
                       valuetype PlayerEnum colorCurrent,
                       valuetype PlayerEnum colorEnemy,
                       int32& changed) cil managed
  {
    // Code size       96 (0x60)
    .maxstack  4
    .locals init ([0] bool V_0)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0007:  ldarg.2
    IL_0008:  ldarg.1
    IL_0009:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_000e:  ldarg.s    colorCurrent
    IL_0010:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0015:  br.s       IL_0040

    IL_0017:  nop
    IL_0018:  ldarg.1
    IL_0019:  ldarg.s    y
    IL_001b:  sub
    IL_001c:  starg.s    coordX
    IL_001e:  ldarg.2
    IL_001f:  ldarg.3
    IL_0020:  sub
    IL_0021:  starg.s    coordY
    IL_0023:  ldarg.0
    IL_0024:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0029:  ldarg.2
    IL_002a:  ldarg.1
    IL_002b:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0030:  ldarg.s    colorCurrent
    IL_0032:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0037:  ldarg.s    changed
    IL_0039:  ldarg.s    changed
    IL_003b:  ldind.i4
    IL_003c:  ldc.i4.1
    IL_003d:  add
    IL_003e:  stind.i4
    IL_003f:  nop
    IL_0040:  ldarg.0
    IL_0041:  ldfld      class BoardSquare[0...,0...] Board::board
    IL_0046:  ldarg.2
    IL_0047:  ldarg.3
    IL_0048:  sub
    IL_0049:  ldarg.1
    IL_004a:  ldarg.s    y
    IL_004c:  sub
    IL_004d:  call       instance class BoardSquare class BoardSquare[0...,0...]::Get(int32,
                                                                                      int32)
    IL_0052:  ldfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0057:  ldarg.s    colorEnemy
    IL_0059:  ceq
    IL_005b:  stloc.0
    IL_005c:  ldloc.0
    IL_005d:  brtrue.s   IL_0017

    IL_005f:  ret
  } // end of method Board::ChangePieces

  .event Board/BoardUpdateEvent boardUpdateEvent
  {
    .addon void Board::add_boardUpdateEvent(class Board/BoardUpdateEvent)
    .removeon void Board::remove_boardUpdateEvent(class Board/BoardUpdateEvent)
  } // end of event Board::boardUpdateEvent
} // end of class Board

.class public auto ansi beforefieldinit BoardSquare
       extends [mscorlib]System.Object
{
  .field public valuetype PlayerEnum belongsToPlayer
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  stfld      valuetype PlayerEnum BoardSquare::belongsToPlayer
    IL_0007:  ldarg.0
    IL_0008:  call       instance void [mscorlib]System.Object::.ctor()
    IL_000d:  nop
    IL_000e:  ret
  } // end of method BoardSquare::.ctor

} // end of class BoardSquare

.class public auto ansi sealed PlayerEnum
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PlayerEnum none = int32(0x00000000)
  .field public static literal valuetype PlayerEnum black = int32(0x00000001)
  .field public static literal valuetype PlayerEnum white = int32(0x00000002)
} // end of class PlayerEnum

.class public auto ansi sealed Direction
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype Direction NW = int32(0x00000000)
  .field public static literal valuetype Direction N = int32(0x00000001)
  .field public static literal valuetype Direction NE = int32(0x00000002)
  .field public static literal valuetype Direction E = int32(0x00000003)
  .field public static literal valuetype Direction SE = int32(0x00000004)
  .field public static literal valuetype Direction S = int32(0x00000005)
  .field public static literal valuetype Direction SW = int32(0x00000006)
  .field public static literal valuetype Direction W = int32(0x00000007)
} // end of class Direction

.class public auto ansi beforefieldinit Game
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public GetValidMovesListEvent
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method GetValidMovesListEvent::.ctor

    .method public hidebysig newslot virtual 
            instance void  Invoke() runtime managed
    {
    } // end of method GetValidMovesListEvent::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method GetValidMovesListEvent::BeginInvoke

    .method public hidebysig newslot virtual 
            instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method GetValidMovesListEvent::EndInvoke

  } // end of class GetValidMovesListEvent

  .class auto ansi sealed nested public GameEndEvent
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method GameEndEvent::.ctor

    .method public hidebysig newslot virtual 
            instance void  Invoke() runtime managed
    {
    } // end of method GameEndEvent::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method GameEndEvent::BeginInvoke

    .method public hidebysig newslot virtual 
            instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method GameEndEvent::EndInvoke

  } // end of class GameEndEvent

  .class auto ansi sealed nested public NextMoveEvent
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method NextMoveEvent::.ctor

    .method public hidebysig newslot virtual 
            instance void  Invoke() runtime managed
    {
    } // end of method NextMoveEvent::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method NextMoveEvent::BeginInvoke

    .method public hidebysig newslot virtual 
            instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method NextMoveEvent::EndInvoke

  } // end of class NextMoveEvent

  .class auto ansi sealed nested public ScoreUpdatedEvent
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method ScoreUpdatedEvent::.ctor

    .method public hidebysig newslot virtual 
            instance void  Invoke() runtime managed
    {
    } // end of method ScoreUpdatedEvent::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method ScoreUpdatedEvent::BeginInvoke

    .method public hidebysig newslot virtual 
            instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method ScoreUpdatedEvent::EndInvoke

  } // end of class ScoreUpdatedEvent

  .field public class Board gameBoard
  .field public class IPlayer black
  .field public class IPlayer white
  .field public int32[][] validMovesAndDirsForThisTurn
  .field public int32 moveCounter
  .field public bool gameIsOver
  .field public class IPlayer currentPlayer
  .field private bool playerSkippedMove
  .field private static class Game/GetValidMovesListEvent getValidMovesListEvent
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private static class Game/GameEndEvent gameEnded
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private static class Game/NextMoveEvent nextMove
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private static class Game/ScoreUpdatedEvent scoreUpdatedEvent
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname static 
          void  add_getValidMovesListEvent(class Game/GetValidMovesListEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/GetValidMovesListEvent V_0,
             class Game/GetValidMovesListEvent V_1,
             class Game/GetValidMovesListEvent V_2)
    IL_0000:  ldsfld     class Game/GetValidMovesListEvent Game::getValidMovesListEvent
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/GetValidMovesListEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/GetValidMovesListEvent Game::getValidMovesListEvent
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/GetValidMovesListEvent>(!!0&,
                                                                                                                        !!0,
                                                                                                                        !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::add_getValidMovesListEvent

  .method public hidebysig specialname static 
          void  remove_getValidMovesListEvent(class Game/GetValidMovesListEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/GetValidMovesListEvent V_0,
             class Game/GetValidMovesListEvent V_1,
             class Game/GetValidMovesListEvent V_2)
    IL_0000:  ldsfld     class Game/GetValidMovesListEvent Game::getValidMovesListEvent
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/GetValidMovesListEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/GetValidMovesListEvent Game::getValidMovesListEvent
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/GetValidMovesListEvent>(!!0&,
                                                                                                                        !!0,
                                                                                                                        !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::remove_getValidMovesListEvent

  .method public hidebysig specialname static 
          void  add_gameEnded(class Game/GameEndEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/GameEndEvent V_0,
             class Game/GameEndEvent V_1,
             class Game/GameEndEvent V_2)
    IL_0000:  ldsfld     class Game/GameEndEvent Game::gameEnded
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/GameEndEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/GameEndEvent Game::gameEnded
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/GameEndEvent>(!!0&,
                                                                                                              !!0,
                                                                                                              !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::add_gameEnded

  .method public hidebysig specialname static 
          void  remove_gameEnded(class Game/GameEndEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/GameEndEvent V_0,
             class Game/GameEndEvent V_1,
             class Game/GameEndEvent V_2)
    IL_0000:  ldsfld     class Game/GameEndEvent Game::gameEnded
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/GameEndEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/GameEndEvent Game::gameEnded
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/GameEndEvent>(!!0&,
                                                                                                              !!0,
                                                                                                              !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::remove_gameEnded

  .method public hidebysig specialname static 
          void  add_nextMove(class Game/NextMoveEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/NextMoveEvent V_0,
             class Game/NextMoveEvent V_1,
             class Game/NextMoveEvent V_2)
    IL_0000:  ldsfld     class Game/NextMoveEvent Game::nextMove
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/NextMoveEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/NextMoveEvent Game::nextMove
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/NextMoveEvent>(!!0&,
                                                                                                               !!0,
                                                                                                               !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::add_nextMove

  .method public hidebysig specialname static 
          void  remove_nextMove(class Game/NextMoveEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/NextMoveEvent V_0,
             class Game/NextMoveEvent V_1,
             class Game/NextMoveEvent V_2)
    IL_0000:  ldsfld     class Game/NextMoveEvent Game::nextMove
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/NextMoveEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/NextMoveEvent Game::nextMove
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/NextMoveEvent>(!!0&,
                                                                                                               !!0,
                                                                                                               !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::remove_nextMove

  .method public hidebysig specialname static 
          void  add_scoreUpdatedEvent(class Game/ScoreUpdatedEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/ScoreUpdatedEvent V_0,
             class Game/ScoreUpdatedEvent V_1,
             class Game/ScoreUpdatedEvent V_2)
    IL_0000:  ldsfld     class Game/ScoreUpdatedEvent Game::scoreUpdatedEvent
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                            class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/ScoreUpdatedEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/ScoreUpdatedEvent Game::scoreUpdatedEvent
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/ScoreUpdatedEvent>(!!0&,
                                                                                                                   !!0,
                                                                                                                   !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::add_scoreUpdatedEvent

  .method public hidebysig specialname static 
          void  remove_scoreUpdatedEvent(class Game/ScoreUpdatedEvent 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Game/ScoreUpdatedEvent V_0,
             class Game/ScoreUpdatedEvent V_1,
             class Game/ScoreUpdatedEvent V_2)
    IL_0000:  ldsfld     class Game/ScoreUpdatedEvent Game::scoreUpdatedEvent
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Remove(class [mscorlib]System.Delegate,
                                                                                           class [mscorlib]System.Delegate)
    IL_000f:  castclass  Game/ScoreUpdatedEvent
    IL_0014:  stloc.2
    IL_0015:  ldsflda    class Game/ScoreUpdatedEvent Game::scoreUpdatedEvent
    IL_001a:  ldloc.2
    IL_001b:  ldloc.1
    IL_001c:  call       !!0 [mscorlib]System.Threading.Interlocked::CompareExchange<class Game/ScoreUpdatedEvent>(!!0&,
                                                                                                                   !!0,
                                                                                                                   !!0)
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldloc.1
    IL_0024:  bne.un.s   IL_0006

    IL_0026:  ret
  } // end of method Game::remove_scoreUpdatedEvent

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class IPlayer first,
                               class IPlayer second) cil managed
  {
    // Code size       67 (0x43)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  stfld      int32 Game::moveCounter
    IL_0007:  ldarg.0
    IL_0008:  ldc.i4.0
    IL_0009:  stfld      bool Game::gameIsOver
    IL_000e:  ldarg.0
    IL_000f:  ldc.i4.0
    IL_0010:  stfld      bool Game::playerSkippedMove
    IL_0015:  ldarg.0
    IL_0016:  call       instance void [mscorlib]System.Object::.ctor()
    IL_001b:  nop
    IL_001c:  nop
    IL_001d:  ldarg.0
    IL_001e:  ldarg.1
    IL_001f:  stfld      class IPlayer Game::black
    IL_0024:  ldarg.0
    IL_0025:  ldarg.2
    IL_0026:  stfld      class IPlayer Game::white
    IL_002b:  ldarg.0
    IL_002c:  newobj     instance void Board::.ctor()
    IL_0031:  stfld      class Board Game::gameBoard
    IL_0036:  ldarg.0
    IL_0037:  ldarg.0
    IL_0038:  ldfld      class IPlayer Game::black
    IL_003d:  stfld      class IPlayer Game::currentPlayer
    IL_0042:  ret
  } // end of method Game::.ctor

  .method public hidebysig instance void 
          InitGame() cil managed
  {
    // Code size       21 (0x15)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class Board Game::gameBoard
    IL_0007:  callvirt   instance void Board::InitBoard()
    IL_000c:  nop
    IL_000d:  ldarg.0
    IL_000e:  call       instance void Game::UpdateValidMovesList()
    IL_0013:  nop
    IL_0014:  ret
  } // end of method Game::InitGame

  .method public hidebysig instance void 
          PlayRound() cil managed
  {
    // Code size       77 (0x4d)
    .maxstack  3
    .locals init ([0] class [mscorlib]System.Collections.Generic.List`1<int32[]> takenCoordsAndDirections,
             [1] int32 beatPiecesCount,
             [2] bool V_2)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  call       instance class [mscorlib]System.Collections.Generic.List`1<int32[]> Game::GetMoveFromPlayer()
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  ldnull
    IL_000a:  ceq
    IL_000c:  stloc.2
    IL_000d:  ldloc.2
    IL_000e:  brfalse.s  IL_0012

    IL_0010:  br.s       IL_004c

    IL_0012:  ldarg.0
    IL_0013:  ldfld      class Board Game::gameBoard
    IL_0018:  ldloc.0
    IL_0019:  ldarg.0
    IL_001a:  ldfld      class IPlayer Game::currentPlayer
    IL_001f:  callvirt   instance int32 Board::UpdateBeatPieces(class [mscorlib]System.Collections.Generic.List`1<int32[]>,
                                                                class IPlayer)
    IL_0024:  stloc.1
    IL_0025:  ldarg.0
    IL_0026:  ldloc.1
    IL_0027:  call       instance void Game::UpdateScore(int32)
    IL_002c:  nop
    IL_002d:  ldarg.0
    IL_002e:  call       instance void Game::ChangePlayer()
    IL_0033:  nop
    IL_0034:  ldarg.0
    IL_0035:  call       instance void Game::UpdateValidMovesList()
    IL_003a:  nop
    IL_003b:  ldsfld     class Game/NextMoveEvent Game::nextMove
    IL_0040:  dup
    IL_0041:  brtrue.s   IL_0046

    IL_0043:  pop
    IL_0044:  br.s       IL_004c

    IL_0046:  callvirt   instance void Game/NextMoveEvent::Invoke()
    IL_004b:  nop
    IL_004c:  ret
  } // end of method Game::PlayRound

  .method public hidebysig instance void 
          UpdateValidMovesList() cil managed
  {
    // Code size       150 (0x96)
    .maxstack  3
    .locals init ([0] bool V_0,
             [1] bool V_1,
             [2] bool V_2,
             [3] bool V_3)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.0
    IL_0003:  ldfld      class Board Game::gameBoard
    IL_0008:  ldarg.0
    IL_0009:  ldfld      class IPlayer Game::currentPlayer
    IL_000e:  callvirt   instance int32[][] Board::GetValidMovesList(class IPlayer)
    IL_0013:  stfld      int32[][] Game::validMovesAndDirsForThisTurn
    IL_0018:  ldsfld     class Game/GetValidMovesListEvent Game::getValidMovesListEvent
    IL_001d:  ldnull
    IL_001e:  cgt.un
    IL_0020:  stloc.0
    IL_0021:  ldloc.0
    IL_0022:  brfalse.s  IL_0031

    IL_0024:  nop
    IL_0025:  ldsfld     class Game/GetValidMovesListEvent Game::getValidMovesListEvent
    IL_002a:  callvirt   instance void Game/GetValidMovesListEvent::Invoke()
    IL_002f:  nop
    IL_0030:  nop
    IL_0031:  ldarg.0
    IL_0032:  ldfld      int32[][] Game::validMovesAndDirsForThisTurn
    IL_0037:  ldlen
    IL_0038:  conv.i4
    IL_0039:  ldc.i4.1
    IL_003a:  clt
    IL_003c:  stloc.1
    IL_003d:  ldloc.1
    IL_003e:  brfalse.s  IL_008e

    IL_0040:  nop
    IL_0041:  ldarg.0
    IL_0042:  call       instance bool Game::IsMaxScore()
    IL_0047:  stloc.2
    IL_0048:  ldloc.2
    IL_0049:  brfalse.s  IL_0059

    IL_004b:  nop
    IL_004c:  ldsfld     class Game/GameEndEvent Game::gameEnded
    IL_0051:  callvirt   instance void Game/GameEndEvent::Invoke()
    IL_0056:  nop
    IL_0057:  br.s       IL_0095

    IL_0059:  ldarg.0
    IL_005a:  ldfld      bool Game::playerSkippedMove
    IL_005f:  ldc.i4.0
    IL_0060:  ceq
    IL_0062:  stloc.3
    IL_0063:  ldloc.3
    IL_0064:  brfalse.s  IL_007f

    IL_0066:  nop
    IL_0067:  ldarg.0
    IL_0068:  ldc.i4.1
    IL_0069:  stfld      bool Game::playerSkippedMove
    IL_006e:  ldarg.0
    IL_006f:  call       instance void Game::ChangePlayer()
    IL_0074:  nop
    IL_0075:  ldarg.0
    IL_0076:  call       instance void Game::UpdateValidMovesList()
    IL_007b:  nop
    IL_007c:  nop
    IL_007d:  br.s       IL_008d

    IL_007f:  nop
    IL_0080:  ldsfld     class Game/GameEndEvent Game::gameEnded
    IL_0085:  callvirt   instance void Game/GameEndEvent::Invoke()
    IL_008a:  nop
    IL_008b:  br.s       IL_0095

    IL_008d:  nop
    IL_008e:  ldarg.0
    IL_008f:  ldc.i4.0
    IL_0090:  stfld      bool Game::playerSkippedMove
    IL_0095:  ret
  } // end of method Game::UpdateValidMovesList

  .method private hidebysig instance bool 
          IsMaxScore() cil managed
  {
    // Code size       33 (0x21)
    .maxstack  2
    .locals init ([0] bool V_0)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class IPlayer Game::black
    IL_0007:  callvirt   instance int32 IPlayer::get_score()
    IL_000c:  ldarg.0
    IL_000d:  ldfld      class IPlayer Game::white
    IL_0012:  callvirt   instance int32 IPlayer::get_score()
    IL_0017:  add
    IL_0018:  ldc.i4.s   64
    IL_001a:  ceq
    IL_001c:  stloc.0
    IL_001d:  br.s       IL_001f

    IL_001f:  ldloc.0
    IL_0020:  ret
  } // end of method Game::IsMaxScore

  .method private hidebysig instance void 
          ChangePlayer() cil managed
  {
    // Code size       36 (0x24)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.0
    IL_0003:  ldfld      class IPlayer Game::currentPlayer
    IL_0008:  ldarg.0
    IL_0009:  ldfld      class IPlayer Game::white
    IL_000e:  beq.s      IL_0018

    IL_0010:  ldarg.0
    IL_0011:  ldfld      class IPlayer Game::white
    IL_0016:  br.s       IL_001e

    IL_0018:  ldarg.0
    IL_0019:  ldfld      class IPlayer Game::black
    IL_001e:  stfld      class IPlayer Game::currentPlayer
    IL_0023:  ret
  } // end of method Game::ChangePlayer

  .method private hidebysig instance void 
          UpdateScore(int32 beatPiecesCount) cil managed
  {
    // Code size       103 (0x67)
    .maxstack  4
    .locals init ([0] bool V_0)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class IPlayer Game::currentPlayer
    IL_0007:  dup
    IL_0008:  callvirt   instance int32 IPlayer::get_score()
    IL_000d:  ldarg.1
    IL_000e:  ldc.i4.1
    IL_000f:  add
    IL_0010:  add
    IL_0011:  callvirt   instance void IPlayer::set_score(int32)
    IL_0016:  nop
    IL_0017:  ldarg.0
    IL_0018:  ldfld      class IPlayer Game::currentPlayer
    IL_001d:  ldarg.0
    IL_001e:  ldfld      class IPlayer Game::black
    IL_0023:  ceq
    IL_0025:  stloc.0
    IL_0026:  ldloc.0
    IL_0027:  brfalse.s  IL_0041

    IL_0029:  nop
    IL_002a:  ldarg.0
    IL_002b:  ldfld      class IPlayer Game::white
    IL_0030:  dup
    IL_0031:  callvirt   instance int32 IPlayer::get_score()
    IL_0036:  ldarg.1
    IL_0037:  sub
    IL_0038:  callvirt   instance void IPlayer::set_score(int32)
    IL_003d:  nop
    IL_003e:  nop
    IL_003f:  br.s       IL_0055

    IL_0041:  ldarg.0
    IL_0042:  ldfld      class IPlayer Game::black
    IL_0047:  dup
    IL_0048:  callvirt   instance int32 IPlayer::get_score()
    IL_004d:  ldarg.1
    IL_004e:  sub
    IL_004f:  callvirt   instance void IPlayer::set_score(int32)
    IL_0054:  nop
    IL_0055:  ldsfld     class Game/ScoreUpdatedEvent Game::scoreUpdatedEvent
    IL_005a:  dup
    IL_005b:  brtrue.s   IL_0060

    IL_005d:  pop
    IL_005e:  br.s       IL_0066

    IL_0060:  callvirt   instance void Game/ScoreUpdatedEvent::Invoke()
    IL_0065:  nop
    IL_0066:  ret
  } // end of method Game::UpdateScore

  .method private hidebysig instance class [mscorlib]System.Collections.Generic.List`1<int32[]> 
          GetMoveFromPlayer() cil managed
  {
    // Code size       129 (0x81)
    .maxstack  3
    .locals init ([0] int32[] selectedSquare,
             [1] class [mscorlib]System.Collections.Generic.List`1<int32[]> takenCoordsAndDirections,
             [2] int32 i,
             [3] bool V_3,
             [4] bool V_4,
             [5] bool V_5,
             [6] class [mscorlib]System.Collections.Generic.List`1<int32[]> V_6)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class IPlayer Game::currentPlayer
    IL_0007:  callvirt   instance int32[] IPlayer::get_currentTurnCoords()
    IL_000c:  stloc.0
    IL_000d:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<int32[]>::.ctor()
    IL_0012:  stloc.1
    IL_0013:  ldc.i4.0
    IL_0014:  stloc.2
    IL_0015:  br.s       IL_0053

    IL_0017:  nop
    IL_0018:  ldarg.0
    IL_0019:  ldfld      int32[][] Game::validMovesAndDirsForThisTurn
    IL_001e:  ldloc.2
    IL_001f:  ldelem.ref
    IL_0020:  ldc.i4.0
    IL_0021:  ldelem.i4
    IL_0022:  ldloc.0
    IL_0023:  ldc.i4.0
    IL_0024:  ldelem.i4
    IL_0025:  bne.un.s   IL_0038

    IL_0027:  ldarg.0
    IL_0028:  ldfld      int32[][] Game::validMovesAndDirsForThisTurn
    IL_002d:  ldloc.2
    IL_002e:  ldelem.ref
    IL_002f:  ldc.i4.1
    IL_0030:  ldelem.i4
    IL_0031:  ldloc.0
    IL_0032:  ldc.i4.1
    IL_0033:  ldelem.i4
    IL_0034:  ceq
    IL_0036:  br.s       IL_0039

    IL_0038:  ldc.i4.0
    IL_0039:  stloc.3
    IL_003a:  ldloc.3
    IL_003b:  brfalse.s  IL_004e

    IL_003d:  nop
    IL_003e:  ldloc.1
    IL_003f:  ldarg.0
    IL_0040:  ldfld      int32[][] Game::validMovesAndDirsForThisTurn
    IL_0045:  ldloc.2
    IL_0046:  ldelem.ref
    IL_0047:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<int32[]>::Add(!0)
    IL_004c:  nop
    IL_004d:  nop
    IL_004e:  nop
    IL_004f:  ldloc.2
    IL_0050:  ldc.i4.1
    IL_0051:  add
    IL_0052:  stloc.2
    IL_0053:  ldloc.2
    IL_0054:  ldarg.0
    IL_0055:  ldfld      int32[][] Game::validMovesAndDirsForThisTurn
    IL_005a:  ldlen
    IL_005b:  conv.i4
    IL_005c:  clt
    IL_005e:  stloc.s    V_4
    IL_0060:  ldloc.s    V_4
    IL_0062:  brtrue.s   IL_0017

    IL_0064:  ldloc.1
    IL_0065:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.List`1<int32[]>::get_Count()
    IL_006a:  ldc.i4.0
    IL_006b:  ceq
    IL_006d:  stloc.s    V_5
    IL_006f:  ldloc.s    V_5
    IL_0071:  brfalse.s  IL_0079

    IL_0073:  nop
    IL_0074:  ldnull
    IL_0075:  stloc.s    V_6
    IL_0077:  br.s       IL_007e

    IL_0079:  ldloc.1
    IL_007a:  stloc.s    V_6
    IL_007c:  br.s       IL_007e

    IL_007e:  ldloc.s    V_6
    IL_0080:  ret
  } // end of method Game::GetMoveFromPlayer

  .event Game/GetValidMovesListEvent getValidMovesListEvent
  {
    .addon void Game::add_getValidMovesListEvent(class Game/GetValidMovesListEvent)
    .removeon void Game::remove_getValidMovesListEvent(class Game/GetValidMovesListEvent)
  } // end of event Game::getValidMovesListEvent
  .event Game/GameEndEvent gameEnded
  {
    .addon void Game::add_gameEnded(class Game/GameEndEvent)
    .removeon void Game::remove_gameEnded(class Game/GameEndEvent)
  } // end of event Game::gameEnded
  .event Game/NextMoveEvent nextMove
  {
    .addon void Game::add_nextMove(class Game/NextMoveEvent)
    .removeon void Game::remove_nextMove(class Game/NextMoveEvent)
  } // end of event Game::nextMove
  .event Game/ScoreUpdatedEvent scoreUpdatedEvent
  {
    .addon void Game::add_scoreUpdatedEvent(class Game/ScoreUpdatedEvent)
    .removeon void Game::remove_scoreUpdatedEvent(class Game/ScoreUpdatedEvent)
  } // end of event Game::scoreUpdatedEvent
} // end of class Game

.class interface public abstract auto ansi IPlayer
{
  .method public hidebysig newslot specialname abstract virtual 
          instance int32  get_score() cil managed
  {
  } // end of method IPlayer::get_score

  .method public hidebysig newslot specialname abstract virtual 
          instance void  set_score(int32 'value') cil managed
  {
  } // end of method IPlayer::set_score

  .method public hidebysig newslot specialname abstract virtual 
          instance bool  get_isHuman() cil managed
  {
  } // end of method IPlayer::get_isHuman

  .method public hidebysig newslot specialname abstract virtual 
          instance void  set_isHuman(bool 'value') cil managed
  {
  } // end of method IPlayer::set_isHuman

  .method public hidebysig newslot specialname abstract virtual 
          instance valuetype PlayerEnum  get_color() cil managed
  {
  } // end of method IPlayer::get_color

  .method public hidebysig newslot specialname abstract virtual 
          instance void  set_color(valuetype PlayerEnum 'value') cil managed
  {
  } // end of method IPlayer::set_color

  .method public hidebysig newslot specialname abstract virtual 
          instance int32[]  get_currentTurnCoords() cil managed
  {
  } // end of method IPlayer::get_currentTurnCoords

  .method public hidebysig newslot specialname abstract virtual 
          instance void  set_currentTurnCoords(int32[] 'value') cil managed
  {
  } // end of method IPlayer::set_currentTurnCoords

  .method public hidebysig newslot abstract virtual 
          instance void  UpdateMoves(int32[][] possibleMoveCoords) cil managed
  {
  } // end of method IPlayer::UpdateMoves

  .property instance int32 score()
  {
    .get instance int32 IPlayer::get_score()
    .set instance void IPlayer::set_score(int32)
  } // end of property IPlayer::score
  .property instance bool isHuman()
  {
    .get instance bool IPlayer::get_isHuman()
    .set instance void IPlayer::set_isHuman(bool)
  } // end of property IPlayer::isHuman
  .property instance valuetype PlayerEnum
          color()
  {
    .get instance valuetype PlayerEnum IPlayer::get_color()
    .set instance void IPlayer::set_color(valuetype PlayerEnum)
  } // end of property IPlayer::color
  .property instance int32[] currentTurnCoords()
  {
    .get instance int32[] IPlayer::get_currentTurnCoords()
    .set instance void IPlayer::set_currentTurnCoords(int32[])
  } // end of property IPlayer::currentTurnCoords
} // end of class IPlayer


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file D:\Programming\Code\C#\Othello\bin\Debug\d2.res
