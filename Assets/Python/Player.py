from UnityEngine import *

player = GameObject.FindGameObjectWithTag("Player")
rb = player.GetComponent(Rigidbody)
anim = player.GetComponent(Animator)
cameraTransform = Camera.main.transform

walkSpeed = 2.5
runSpeed = 7
currentSpeed = walkSpeed
isRun = False

mouseSensitivity = 2.0
verticalRotationLimit = 80.0
cameraRotationX = 0.0

isGrounded = False

Debug.Log("Start")

Cursor.lockState = CursorLockMode.Locked
Cursor.visible = False

def Update():
    global currentSpeed, isRun
    HandleInput()
    Move()
    RotateCamera()
    CheckGroundStatus()

def HandleInput():
    global currentSpeed, isRun
    if Input.GetKeyDown(KeyCode.Escape):
        Cursor.lockState = CursorLockMode.Confined
        Cursor.visible = True
    if Input.GetKeyDown(KeyCode.Space):
        Jump()
    if Input.GetKey(KeyCode.LeftShift):
        currentSpeed = runSpeed
        isRun = True
    else:
        currentSpeed = walkSpeed
        isRun = False

def Move():
    horizontal = Input.GetAxisRaw("Horizontal")
    vertical = Input.GetAxisRaw("Vertical")
    move_value = 2 if isRun else 1
    anim.SetFloat("Horizontal", horizontal * move_value)
    anim.SetFloat("Vertical", vertical * move_value)

    movement = cameraTransform.TransformDirection(Vector3(horizontal, 0, vertical)) * currentSpeed
    movement.y = rb.velocity.y
    rb.velocity = movement

def RotateCamera():
    global cameraRotationX
    mouseX = Input.GetAxis("Mouse X") * mouseSensitivity
    mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity
    cameraRotationX -= mouseY
    cameraRotationX = Mathf.Clamp(cameraRotationX, -verticalRotationLimit, verticalRotationLimit)
    cameraTransform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0)
    player.transform.Rotate(Vector3.up * mouseX)

def CheckGroundStatus():
    global isGrounded
    isGrounded = Physics.Raycast(player.transform.position + Vector3(0, 1, 0), Vector3.down, 1)


def Jump():
    if isGrounded:
        rb.AddForce(Vector3.up * 200)
        anim.SetTrigger("IsJump")
