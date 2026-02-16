# Unity Jump&Run Project

A small selection of scripts from a platform-based 3D Jump&Run prototype developed in Unity(C#)

## Overview
This repository contains implementations of key gameplay mechanics. The goal is to demonstrate code structures and logic used within the scripts

## Included Systems

### Pressure Plate System
Related Files:
- PressurePlate.cs
- PressurePlateManager.cs

Features:
- Detects objects entering and exiting trigger zones
- Supports multiple objects on a plate using a HashSet
- Activates linked objects only when all plates are pressed
- Prevents duplicate trigger registration

### Timed Platform System
Related File:
- PlatformBlink.cs

Features:
- Platforms toggle active state on a cycle
- Adjustable cycle time via Inspector parameters
- Optional start delay

## Tech Stack
- Unity Engine
- C#
- MonoBehaviour architecture

## Context
These scripts were created as part of an university game development project and represent examples for gameplay logic rather than a full project build

Gameplay video:
https://youtu.be/E1SAFczIWeg
