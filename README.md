## 📖 목차

1. [개요](#-개요)
2. [핵심 기능 설명](#-핵심-기능-설명)
3. [클래스 구조](#-클래스-구조)
4. [개발 환경](#개발-환경)


# Inventory 개인과제


## ✨ 개요

Inventory 개인 과제 제출용 Repository

3개의 플레이어가 존재하고, select 버튼을 누르면 해당 플레이어의 status와 inventory에 접근
status와 inventory UI가 켜져 있는 상황에서도 플레이어를 전환 가능
inventory의 아이템을 장착하면 해당 스텟이 상승하고, save 버튼을 누를 시 장착 정보는 csv 파일에 저장

## 🔧 핵심 기능 설명

## 주요 기능 및 시스템

### 1. Character : 플레이어 데이터 관리
- `Character`: 캐릭터의 아이템 장착 부분을 관리
- `Player`: Character 클래스를 상속받고, 플레이어 스텟과 장착하고 있는 아이템 리스트를 인스턴스에 적용하고, 인스턴스의 정보를 다시 저장할 수 있도록 컨트롤

### 2. Core : 게임 시스템 관리
- `GameManager` 플레이어 데이터를 csv 파일에서 받아오고, 저장 시 수정 기능 

### 3. Item : 아이템 데이터, 아이템 에디터
- `ItemData` ScriptableObject로 생성될 아이템 정보
- `ItemCreator` ItemData 클래스 아이템을 생성하는 에디터

### 4. UI : UI 시스템
- `UIManager` UI를 전부 관리하는 매니저 클래스
- `UIMainMenu` 메인 메뉴 UI
- `UIInventory` 인벤토리 UI
- `UIStatus` 스테이터스 UI
- `InventorySlot` 인벤토리에 아이템 개수만큼 자동으로 생성되는 slot 
- `SelectButton` 플레이어 오브젝트 아래 select 버튼을 누를 시, 플레이어 데이터 업데이트

### 5. PlayerData : 플레이어 데이터
- `PlayerData` 


## 📊 클래스 구조

```
Assets/
  ├── 01_Scenes/                # 씬
  ├── 02_Scripts/               # 스크립트
  │   ├── Character/            # 캐릭터 스크립트, 캐릭터 스크립트를 상속받은 player 스크립트,
  │   ├── Core/                 # GameManager
  │   ├── Item/                 # 아이템 데이터, 아이템을 생성할 수 있는 에디터
  │   ├── UI/                   # UIManager에서 mainmenu, stutas, inventory UI 관리
  │   └── PlayerData/           # 플레이어 데이터, 관리는 gameManager에서 함
  ├── 03_Prefabs/               # 재사용 가능한 프리팹(맵 오브젝트, 장착 오브젝트, 아이템 슬롯 UI, 아이템)
  ├── 04_Images/                # 게임에 사용된 스프라이트
  ├── 05_Animations/            # 애니메이션
  ├── Resources/                # scriptableObject들을 resource에서 관리
  ├── StreamingAssets/          # PlayerData를 StreamingAssets에서 관리
  └── Palette/                  # 뒷 배경을 제작하는데 사용된 팔레트
```


## 개발 환경

* **엔진**: Unity 2022.3.17f1 (LTS)
* **언어**: C#
* **IDE**: JetBrains Rider

---
