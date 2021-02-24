using UnityEngine;
using UnityEngine.Events;

namespace SquareManShootTetris 
{ 
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public abstract class AbstractBlock : MonoBehaviour, ISpawneable, IDestructable
    {
        #region Dependencies 
        public DifficultyManager difficultyManager;
        private Rigidbody rb;
        private SpawneablesHandeler spawneablesHandeler;
        #endregion

        #region Public Variables
        public LayerMask collisionLayerMask;
        #endregion

        #region Private Variables
        //Show In Inspector
        [Header("Settings")]
        [SerializeField] private int durability = 1;
        [SerializeField] private int scorePoints = 1;

        //Keep it private
        private bool isFalling = true; //Quitar solo para pruebas
        #endregion

        #region Properties
        //ISpawneable Porperties
        public Transform ITransform => transform;
        public GameObject IGameObject => gameObject;
        public int Durability => durability;
        public float ScorePoints => scorePoints;

        //Block Properties
        public bool IsFalling => isFalling;

        public SpawningManager Sp { get; private set; }
        #endregion

        #region Events
        public UnityEvent OnDestroyed;
        #endregion

        #region Builtin Methods
        public virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            difficultyManager = FindObjectOfType<DifficultyManager>();
            spawneablesHandeler = FindObjectOfType<SpawneablesHandeler>();
        }

        private void Update()
        {
            CheckForCollisions();
            
        }

        public virtual void FixedUpdate() 
        {
            if (IsFalling)
            {
                Fall();
            }
        }


        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Shot")
            {
                Debug.Log(name + " has been hit");
                DecreaseDurability();
                Destroy(other.gameObject);
            }
        }
        #endregion
        #region Main Methods
        public void Initialize(SpawningManager sp) 
        {
            Sp = sp;
        }
        public virtual void Fall() 
        {
            rb.MovePosition(new Vector3(transform.position.x, transform.position.y - (difficultyManager.Gravity * Time.deltaTime), transform.position.z));
        }

        private void CheckForCollisions ()
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(transform.position, -transform.up, out hitInfo, 0.65f, collisionLayerMask))
            {
                //Debug.Log(hitInfo.point);
                isFalling = false;
                if (hitInfo.collider.CompareTag("Ground"))
                {
                    transform.position = new Vector3(transform.position.x, hitInfo.collider.transform.position.y + 0.65f, transform.position.z);
                }
                if (hitInfo.collider.CompareTag("Block"))
                {
                    transform.position = new Vector3(transform.position.x, hitInfo.collider.transform.position.y + transform.lossyScale.y, transform.position.z);
                }
            }
            else 
            {
                isFalling = true;
            }
        }

        public virtual void DecreaseDurability() 
        {
            if (durability <= 1)
            {
                getDestroyed();
            }
            else
            {                
                durability--;
            }
        }

        public void getDestroyed() 
        {
            spawneablesHandeler.RemoveRemove(GetComponent<ISpawneable>(),SpawneableTpye.BLOCKS);
            Debug.Log(name + "removed from Spawned Blocks list. Num of spaneables: " + spawneablesHandeler.getSpawnedItemsFrom(SpawneableTpye.BLOCKS));
            Destroy(gameObject);
        }
        #endregion
#region Editor and Drawing
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawRay(transform.position, -transform.up);
        }

#endif
        #endregion
    }


}
