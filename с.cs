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

# Создаём руки (кубы)
bpy.ops.mesh.primitive_cube_add(size=0.3, location = (-0.8, 0, 1.2))
left_arm = bpy.context.active_object
left_arm.name = "LeftArm"

bpy.ops.mesh.primitive_cube_add(size=0.3, location = (0.8, 0, 1.2))
right_arm = bpy.context.active_object
right_arm.name = "RightArm"

# Создаём ноги (кубы)
bpy.ops.mesh.primitive_cube_add(size=0.5, location = (-0.3, 0, 0.25))
left_leg = bpy.context.active_object
left_leg.name = "LeftLeg"

bpy.ops.mesh.primitive_cube_add(size=0.5, location = (0.3, 0, 0.25))
right_leg = bpy.context.active_object
right_leg.name = "RightLeg"
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

# Функция для создания костей
def create_bone(name, head, tail):
    bone = armature.data.edit_bones.new(name)
    bone.head = head
    bone.tail = tail
    return bone

# Кости для отжиманий
root_bone = create_bone("Root", (0, 0, 0), (0, 0, 1))
spine_bone = create_bone("Spine", (0, 0, 1), (0, 0, 2))
shoulder_bone_l = create_bone("LeftShoulder", (0, 0, 1.8), (-0.8, 0, 1.8))
shoulder_bone_r = create_bone("RightShoulder", (0, 0, 1.8), (0.8, 0, 1.8))
arm_bone_l = create_bone("LeftArm", (-0.8, 0, 1.8), (-0.8, 0, 1.0))
arm_bone_r = create_bone("RightArm", (0.8, 0, 1.8), (0.8, 0, 1.0))
forearm_bone_l = create_bone("LeftForearm", (-0.8, 0, 1.0), (-0.8, 0, 0.4))
forearm_bone_r = create_bone("RightForearm", (0.8, 0, 1.0), (0.8, 0, 0.4))

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

# Функция для создания костей
def create_bone(name, head, tail):
    bone = armature.data.edit_bones.new(name)
    bone.head = head
    bone.tail = tail
    return bone

# Кости для отжиманий
root_bone = create_bone("Root", (0, 0, 0), (0, 0, 1))
spine_bone = create_bone("Spine", (0, 0, 1), (0, 0, 2))
shoulder_bone_l = create_bone("LeftShoulder", (0, 0, 1.8), (-0.8, 0, 1.8))
shoulder_bone_r = create_bone("RightShoulder", (0, 0, 1.8), (0.8, 0, 1.8))
arm_bone_l = create_bone("LeftArm", (-0.8, 0, 1.8), (-0.8, 0, 1.0))
arm_bone_r = create_bone("RightArm", (0.8, 0, 1.8), (0.8, 0, 1.0))
forearm_bone_l = create_bone("LeftForearm", (-0.8, 0, 1.0), (-0.8, 0, 0.4))
forearm_bone_r = create_bone("RightForearm", (0.8, 0, 1.0), (0.8, 0, 0.4))

# Возвращаемся в объектный режим
bpy.ops.object.mode_set(mode='OBJECT')
# Привязываем объекты к арматуре
for obj in [body, head, left_arm, right_arm, left_leg, right_leg]:
    mod = obj.modifiers.new("Armature", 'ARMATURE')
    mod.object = armature

# Устанавливаем родительские связи
body.parent = armature
body.parent_type = 'BONE'
body.parent_bone = "Spine"

left_arm.parent = armature
left_arm.parent_type = 'BONE'
left_arm.parent_bone = "LeftForearm"

right_arm.parent = armature
right_arm.parent_type = 'BONE'
right_arm.parent_bone = "RightForearm"

left_leg.parent = armature
left_leg.parent_type = 'BONE'
left_leg.parent_bone = "Root"

right_leg.parent = armature
right_leg.parent_type = 'BONE'
right_leg.parent_bone = "Root"
# Привязываем объекты к арматуре
for obj in [body, head, left_arm, right_arm, left_leg, right_leg]:
    mod = obj.modifiers.new("Armature", 'ARMATURE')
    mod.object = armature

# Устанавливаем родительские связи
body.parent = armature
body.parent_type = 'BONE'
body.parent_bone = "Spine"

left_arm.parent = armature
left_arm.parent_type = 'BONE'
left_arm.parent_bone = "LeftForearm"

right_arm.parent = armature
right_arm.parent_type = 'BONE'
right_arm.parent_bone = "RightForearm"

left_leg.parent = armature
left_leg.parent_type = 'BONE'
left_leg.parent_bone = "Root"

right_leg.parent = armature
right_leg.parent_type = 'BONE'
right_leg.parent_bone = "Root"
# Настройка анимации
scene = bpy.context.scene
scene.frame_start = 1
scene.frame_end = 90

# Функция для установки ключевых кадров
def set_keyframe(bone_name, frame, rotation=None, location=None):
    bone = armature.pose.bones[bone_name]
    if rotation:
        bone.rotation_euler = rotation
        bone.keyframe_insert(data_path="rotation_euler", frame=frame)
    if location:
        bone.location = location
        bone.keyframe_insert(data_path="location", frame=frame)

# Кадр 1: исходное положение (упор лёжа)
set_keyframe("Root", 1, location=(0, 0, 0))
set_keyframe("Spine", 1, rotation=(0, 0, 0))
set_keyframe("LeftShoulder", 1, rotation=(0, 0, 0))
set_keyframe("RightShoulder", 1, rotation=(0, 0, 0))
set_keyframe("LeftArm", 1, rotation=(0, math.radians(-90), 0))  # Руки выпрямлены
set_keyframe("RightArm", 1, rotation=(0, math.radians(-90), 0))
set_keyframe("LeftForearm", 1, rotation=(0, 0, 0))
set_keyframe("RightForearm", 1, rotation=(0, 0, 0))

# Кадр 30: сгибание рук (опускание тела)
set_keyframe("Root", 30, location=(0, 0, -0.6))  # Опускание тела
set_keyframe("Spine", 30, rotation=(math.radians(5), 0, 0))  # Небольшой прогиб
set_keyframe("LeftArm", 30, rotation=(0, math.radians(-135), 0))  # Сгибание локтя
set_keyframe("RightArm", 30, rotation=(0, math.radians(-135), 0))
set_keyframe("LeftForearm", 30, rotation=(0, math.radians(45), 0))
set_keyframe("RightForearm", 30, rotation=(0, math.radians(45), 0))

# Кадр 60: максимальное опускание
set_keyframe("Root", 60, location=(0, 0, -1.0))  # Максимальное опускание
set_keyframe("Spine", 60, rotation=(math.radians(10), 0, 0))
set_keyframe("LeftArm", 60, rotation=(0, math.radians(-150), 0))
set_keyframe("RightArm", 60, rotation=(0, math.radians(-150), 0))
set_keyframe("LeftForearm", 60, rotation=(0, math.radians(60), 0))
set_keyframe("RightForearm", 60, rotation=(0, math.# Настройка анимации
scene = bpy.context.scene
scene.frame_start = 1
scene.frame_end = 90

# Функция для установки ключевых кадров
def set_keyframe(bone_name, frame, rotation=None, location=None):
    bone = armature.pose.bones[bone_name]
    if rotation:
        bone.rotation_euler = rotation
        bone.keyframe_insert(data_path="rotation_euler", frame=frame)
    if location:
        bone.location = location
        bone.keyframe_insert(data_path="location", frame=frame)

# Кадр 1: исходное положение (упор лёжа)
set_keyframe("Root", 1, location=(0, 0, 0))
set_keyframe("Spine", 1, rotation=(0, 0, 0))
set_keyframe("LeftShoulder", 1, rotation=(0, 0, 0))
set_keyframe("RightShoulder", 1, rotation=(0, 0, 0))
set_keyframe("LeftArm", 1, rotation=(0, math.radians(-90), 0))  # Руки выпрямлены
set_keyframe("RightArm", 1, rotation=(0, math.radians(-90), 0))
set_keyframe("LeftForearm", 1, rotation=(0, 0, 0))
set_keyframe("RightForearm", 1, rotation=(0, 0, 0))

# Кадр 30: сгибание рук (опускание тела)
set_keyframe("Root", 30, location=(0, 0, -0.6))  # Опускание тела
set_keyframe("Spine", 30, rotation=(math.radians(5), 0, 0))  # Небольшой прогиб
set_keyframe("LeftArm", 30, rotation=(0, math.radians(-135), 0))  # Сгибание локтя
set_keyframe("RightArm", 30, rotation=(0, math.radians(-135), 0))
set_keyframe("LeftForearm", 30, rotation=(0, math.radians(45), 0))
set_keyframe("RightForearm", 30, rotation=(0, math.radians(45), 0))

# Кадр 60: максимальное опускание
set_keyframe("Root", 60, location=(0, 0, -1.0))  # Максимальное опускание
set_keyframe("Spine", 60, rotation=(math.radians(10), 0, 0))
set_keyframe("LeftArm", 60, rotation=(0, math.radians(-150), 0))
set_keyframe("RightArm", 60, rotation=(0, math.radians(-150), 0))
set_keyframe("LeftForearm", 60, rotation=(0, math.radians(60), 0))
set_keyframe("RightForearm", 60, rotation=(0, math.
