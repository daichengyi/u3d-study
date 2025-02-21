using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemEditor : EditorWindow
{
    private ItemDataList_SO dataBase;
    private List<ItemDetails> itemList = new List<ItemDetails>();
    private VisualTreeAsset itemRowTemplate;

    //获得 VisualElement 组件
    private ListView itemListView;

    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("M STUDIO/ItemEditor")]//菜单栏路径
    public static void ShowExample()
    {
        ItemEditor wnd = GetWindow<ItemEditor>();
        wnd.titleContent = new GUIContent("ItemEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        // VisualElement label = new Label("Hello World! From C#");
        // root.Add(label);

        // // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        //拿到模板数据
        itemRowTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UI Builder/ItemRowTemplate.uxml");

        //获得 ListView 组件
        // root 对应 Container
        itemListView = root.Q<VisualElement>("ItemList").Q<ListView>("ListView");

        //加载数据
        LoadDataBase();
        //生成 ListView
        GenerateListView();
    }

    private  void LoadDataBase(){
        //查找对应类型文件
        string[] dataArray = AssetDatabase.FindAssets("ItemDataList_SO");
        if(dataArray.Length > 0){
            var path = AssetDatabase.GUIDToAssetPath(dataArray[0]);
            dataBase = AssetDatabase.LoadAssetAtPath(path, typeof(ItemDataList_SO)) as ItemDataList_SO;
        }

        itemList = dataBase.itemDetailsList;
        //如果不标记则无法保存数据
        EditorUtility.SetDirty(dataBase);
        // Debug.Log(itemList[0].itemID);
    }

    private void GenerateListView(){
        Func<VisualElement> makeItem = () =>itemRowTemplate.CloneTree();
        Action<VisualElement, int> bindItem = (e, i) =>{
            if(i < itemList.Count){
                if(itemList[i].itemIcon){
                    e.Q<VisualElement>("Icon").style.backgroundImage = itemList[i].itemIcon.texture;
                }
                e.Q<Label>("Name").text = itemList[i] == null?"NO_ITEM":itemList[i].itemName;
            }
        };
        
        itemListView.itemsSource = itemList;
        itemListView.makeItem = makeItem;
        itemListView.bindItem = bindItem;
    }
}
