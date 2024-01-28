using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shankOscillation : MonoBehaviour
{
    public Slider resistanceSlider;
    public Toggle claspKnifeToggle;
    private Rigidbody shankRB;
    private List<float> xRotations;
    private float currentRotation, previousRotation, maxRotation, vel, angVel;
    private HingeJoint hinge;
    private JointSpring hingeSpring;
    public Text velText, angVelText;

    // Start is called before the first frame update
    void Start()
    {
        resistanceSlider.minValue = 1f;
        resistanceSlider.maxValue = 4f;
        // resistanceSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        shankRB = GetComponent<Rigidbody>();
        xRotations = new List<float>();
        hinge = GetComponent<HingeJoint>();
        hingeSpring = hinge.spring;
    }

    // Update is called once per frame
    void Update()
    {
        vel = shankRB.velocity.magnitude;
        angVel = shankRB.angularVelocity.magnitude;
        if (vel < -0.01f)
        {
            vel = 0;
        }

        if (angVel < -0.01f)
        {
            angVel = 0;
        }

        if (claspKnifeToggle.isOn)
        {
            simulateClaspKnife();
        }
        else
        {
            ValueChangeCheck();
        }

        velText.text = vel.ToString();
        angVelText.text = angVel.ToString();

        float smooth = Time.deltaTime;
        transform.localEulerAngles = new Vector3(imuSensorControl.arX * -smooth, imuSensorControl.arY * -smooth, imuSensorControl.arZ * -smooth);
    }

    public void ValueChangeCheck()
    {
        shankRB.angularDrag = resistanceSlider.value;
        hingeSpring.damper = resistanceSlider.value / 4;
        hinge.spring = hingeSpring;
    }

    public void simulateClaspKnife()
    {
        shankRB.angularDrag = Mathf.Pow(2f, transform.rotation.x * 10f);
        hingeSpring.damper = Mathf.Pow(2f, transform.rotation.x * 10f) / 4;
        hinge.spring = hingeSpring;
    }

    // public void simulateClaspKnife2()
    // {
    //     currentRotation = transform.rotation.x;

    //     if (currentRotation < 0.1)
    //     {
    //         xRotations.Clear();
    //     }
    //     else
    //     {
    //         xRotations.Add(currentRotation);
    //     }

    //     if (currentRotation - previousRotation < 0)
    //     {
    //         maxRotation = Mathf.Max(xRotations.ToArray());
    //         if (currentRotation - maxRotation <= maxRotation * 3 / 4)
    //         {
    //             shankRB.angularDrag = 10f;
    //         }
    //     }
    //     else
    //     {
    //         shankRB.angularDrag = 0.5f;
    //     }

    //     previousRotation = currentRotation;
    // }
}
