import bpy
import math

# Очищаем сцену
bpy.ops.object.select_all(action='SELECT')
bpy.ops.object.delete()

# Создаём тело (куб)
bpy.ops.mesh.primitive_cube_add(size=1, location = (0, 0, 1))
body = bpy.context.active_object
body.name = "Body"

# Создаём голову (сфера)
bpy.ops.mesh.primitive_uv_sphere_add(radius=0.4, location = (0, 0, 2.5))
head = bpy.context.active_object
head.name = "Head"

# Создаём ноги (кубы)
bpy.ops.mesh.primitive_cube_add(size=0.5, location = (-0.3, 0, 0.25))
left_leg = bpy.context.active_object
left_leg.name = "LeftLeg"

bpy.ops.mesh.primitive_cube_add(size=0.5, location = (0.3, 0, 0.25))
right_leg = bpy.context.active_object
right_leg.name = "RightLeg"



шаг 2
# Создаём арматуру
bpy.ops.object.armature_add(location=(0, 0, 1))
armature = bpy.context.active_object
armature.name = "Armature"

# Переходим в режим редактирования арматуры
bpy.context.view_layer.objects.active = armature
bpy.ops.object.mode_set(mode='EDIT')

# Удаляем кость по умолчанию
bone = armature.data.edit_bones['Bone']
armature.data.edit_bones.remove(bone)

# Создаём кости
def create_bone(name, head, tail):
    bone = armature.data.edit_bones.new(name)
    bone.head = head
    bone.tail = tail
    return bone

# Кости для приседа
root_bone = create_bone("Root", (0, 0, 0), (0, 0, 1))
spine_bone = create_bone("Spine", (0, 0, 1), (0, 0, 2))
leg_bone_l = create_bone("LeftLeg", (0, 0, 0), (-0.3, 0, 0.5))
leg_bone_r = create_bone("RightLeg", (0, 0, 0), (0.3, 0, 0.5))
knee_bone_l = create_bone("LeftKnee", (-0.3, 0, 0.5), (-0.3, 0, 1))
knee_bone_r = create_bone("RightKnee", (0.3, 0, 0.5), (0.3, 0, 1))

# Возвращаемся в объектный режим
bpy.ops.object.mode_set(mode='OBJECT')
# Создаём арматуру
bpy.ops.object.armature_add(location=(0, 0, 1))
armature = bpy.context.active_object
armature.name = "Armature"

# Переходим в режим редактирования арматуры
bpy.context.view_layer.objects.active = armature
bpy.ops.object.mode_set(mode='EDIT')

# Удаляем кость по умолчанию
bone = armature.data.edit_bones['Bone']
armature.data.edit_bones.remove(bone)

# Создаём кости
def create_bone(name, head, tail):
    bone = armature.data.edit_bones.new(name)
    bone.head = head
    bone.tail = tail
    return bone

# Кости для приседа
root_bone = create_bone("Root", (0, 0, 0), (0, 0, 1))
spine_bone = create_bone("Spine", (0, 0, 1), (0, 0, 2))
leg_bone_l = create_bone("LeftLeg", (0, 0, 0), (-0.3, 0, 0.5))
leg_bone_r = create_bone("RightLeg", (0, 0, 0), (0.3, 0, 0.5))
knee_bone_l = create_bone("LeftKnee", (-0.3, 0, 0.5), (-0.3, 0, 1))
knee_bone_r = create_bone("RightKnee", (0.3, 0, 0.5), (0.3, 0, 1))

# Возвращаемся в объектный режим
bpy.ops.object.mode_set(mode='OBJECT')
