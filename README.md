<br/>
<br/>

# <p align="center"> **W5_GroupThreeNotIncluded**  </p>

##### <p align="center"> <b> 내일 배움 캠프 5주차 팀프로젝트 </b>

<br/>
<br/>

<br/>

## 📖 목차
1. [팀소개](#팀소개)
2. 

   
1. [팀소개](#팀소개)
3. [프로젝트 계기](#프로젝트-계기)
4. [주요기능](#주요기능)
5. [개발기간](#개발기간)
6. [기술스택](#기술스택)
7. [서비스 구조](#서비스-구조)
8. [와이어프레임](#와이어프레임)
9. [API 명세서](#API-명세서)
10. [ERD](#ERD)
11. [프로젝트 파일 구조](#프로젝트-파일-구조)
12. [Trouble Shooting](#trouble-shooting)

### ✨팀소개
| 이름   | 직책 | 직무 |
|--------|------|------|
| 정승연 | 팀장 | 프로젝트 매니징, 인풋시스템&플레이어 오브젝트, 아이템 시스템, UI 및 시각효과 |
| 권태하 | 팀원 | 적 생성, 플레이어와 적의 공격, 난이도 조정, Coop 모드 |
| 김신우 | 팀원 | Managers 기초 스크립팅, 랭킹 시스템, 저장 시스템 |
| 박유창 | 팀원 | 게임 기초 UI, 게임 오디오(배경음악, 효과음) |


---

### ✨프로젝트  

 `Info` **Unity를 활용한 고전게임 재해석하기 - dodge**

 `Stack` C#, Unity-2022.3.17f, Visual Studio2022-17.9.6   

 `Made by` **정승연, 권태하, 김신우, 박유창** 

---

### ✨깃 컨벤션

- commit 규칙
    - init: 최초 커밋: Unity 프로젝트 생성
    - feat: 기능 추가
    - refactor: 기능 개선
    - add: 에셋, .cs 등 파일 추가
    - move: 파일 이동, 코드 이동 등
    - remove: 파일 삭제
    - art: UI 개선
    - fix: 버그 수정
    - chore: 기타 잡일
    - docs: 리드미 등 문서 수정
 
- branch
    - dev (하루에 한 번 main 업데이트)
    - branch는 기능마다 1개씩.
        - 기능 추가 시: feat/(기능 이름)
        - UI 추가 시: UI/(추가하는 UI) ->맵처럼 큰 규모만.

---

### ✨ 기능 소개
- **필수 구현 사항**
    - **게임 화면**: 게임을 플레이할 수 있는 화면을 만들어야 합니다. 화면 크기, 배경 등을 설정해야 합니다.
    - **캐릭터**: 주인공 캐릭터와 적 캐릭터를 만들고, 이들을 움직일 수 있도록 구현해야 합니다. 주인공 캐릭터는 플레이어의 조작에 따라 움직여야 하며, 적 캐릭터는 일정한 패턴에 따라 움직여야 합니다.
    - **총알과 공격**: 주인공 캐릭터가 총알을 발사할 수 있도록 구현하고, 적 캐릭터에게 공격을 가할 수 있어야 합니다. 또한, 적 캐릭터의 공격 동작을 정의해야 합니다.
    - **충돌 감지**: 총알과 적 캐릭터가 충돌했는지를 감지하고, 충돌 시 적 캐릭터를 제거하고 점수를 증가시켜야 합니다.
    - **게임 로직**: 게임의 기본 로직을 구현해야 합니다. 게임 시작, 종료, 점수, 생명 등을 관리해야 합니다.
- **선택 구현 사항**
    - **게임 난이도 조절**: 난이도를 조절하기 위해 적의 이동 속도, 총알의 발사 속도, 적의 패턴 등을 조절할 수 있습니다.
    - **아이템 시스템**: 게임을 더 흥미롭게 만들기 위해 아이템 시스템을 도입할 수 있습니다. 플레이어가 아이템을 획득하면 임시로 강화되는 아이템, 체력을 회복하는 아이템 등을 추가할 수 있습니다.
    - **특수 능력**: 플레이어 캐릭터에 특수 능력을 부여하여 게임 플레이를 다양화할 수 있습니다. 예를 들어, 무적 모드, 빠른 이동 모드 등을 추가할 수 있습니다.
    - **멀티플레이어 모드**: 다른 플레이어와 함께 플레이할 수 있는 로컬 멀티플레이어 모드를 추가할 수 있습니다.
    - **시각적 효과**: 게임에 다양한 시각적 효과를 추가하여 게임의 시각적 품질을 향상시킬 수 있습니다.
    - **사운드 효과**: 게임에 배경 음악과 효과음을 추가하여 게임의 분위기를 높일 수 있습니다.

--- 

### ✨ 트러블슈팅

1. COOP 모드의 Player1 미작동.
![image](https://github.com/Charen523/GroupThreeNotIncluded/assets/144107013/209a5656-6408-4cbf-b2df-b602dc33ea81)

2. 무한 부스트 시스템.
![image](https://github.com/Charen523/GroupThreeNotIncluded/assets/144107013/c3f657fe-74eb-464a-a53a-eb045505f0e2)

3. 피할 수 없는 유도탄.
![image](https://github.com/Charen523/GroupThreeNotIncluded/assets/144107013/6f0faec6-2c11-458d-91ce-37c05d70bbec)

4. 중복 불가능한 랭킹 이름.
![image](https://github.com/Charen523/GroupThreeNotIncluded/assets/144107013/32816322-c572-44b1-8195-6ee9db0f9ebe)

5. 랜덤 BGM.
![image](https://github.com/Charen523/GroupThreeNotIncluded/assets/144107013/12887de9-58dc-4e9b-bd9b-5503db0a76fd)
