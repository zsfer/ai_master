# Activity 101: Baked navmesh on Runtime

** submitted by John Seifer Albacete **

## Assignment instructions
Randomly generate obstanles everytime the game starts. Make sure that the AI can traverse on the generated map.

## What I did 
1. generate map using perlin noise
2. bake navmesh using `surface.BuildNavMesh()`
3. use my `_Global/ClickMoveAgent` to traverse around da world

## important notes !!
make sure that the `BakedNavmesh::_mapSize` is the same as your plane/surface's object size/scale. (e.g. ProBuilder object size: Vec3(50, 1, 50) = _mapSize = Vec2(50, 50))
