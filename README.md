# DefenseRPG

## 게임 소개
```
- 스폰되는 몬스터들을 제거하여 성장하는 방치형 디펜스 RPG게임이다.
- 몬스터는 스테이지가 지날수록 강해진다.
- 공격력과 방어력을 높일 수 있으며, 방어력은 해당 스테이지에서 버틸 수 있는 몬스터의 수이다.
- 4가지 탱크를 구입할 수 있으며, 각 탱크당 11대까지 구매가 가능하다.
- 4가지 스킬을 구입할 수 있으며 스킬 슬롯에 장착하면 자동으로 스킬을 시전한다.
- 스킬은 이펙트가 있는 지역스킬과 이펙트가 없는 버프스킬이 있다.
- 오프라인에서 최대 480분까지 시간 보상이 있다.
```

## 코드 기법

* #### 싱글턴 패턴
  - 고유한 MainManager를 통해서만 각 매니저 컴포넌트들을 호출할 수 있다.

* #### 옵저버 패턴
  - Action을 이용하여 각 이벤트 발생 시 각 함수에게 알려준다.

* #### 오브젝트 풀링
  - 게임에서는 몬스터와 탱크, 탱크가 발사하는 대포가 있다. 각 오브젝트들은 기본 10개씩 생성되며, 스택으로 관리한다.

* #### 코루틴
  - 지정 시간마다 몬스터들을 지정 지역에서 스폰한다.
  - 탱크는 타겟이 있을 경우 지정 시간마다 대포를 발사한다.
  - 지정 시간마다 스킬슬롯에 있는 스킬들이 시전된다.

## 게임 제작 후 배운 점
```
두 개의 미니게임 제작 후 처음 만든 RPG 프로젝트이다. 생각보다 신경쓸게 많았고 그 과정에서 많은 것을 배운 것 같다.
현재는 데이터를 Json으로 저장하고 로드하지만 추후에는 서버와 DB를 연동하고 여러 컨텐츠를 추가해야겠다.
```

* #### 로딩 화면
  - 해당 게임에서는 그래픽이 복잡하지 않기에 렌더링 속도가 빠르기 때문에 로딩화면이 필요가 없지만 강제적으로 지연 시간을 주어 로딩 화면을 추가하였다.
  - 비동기로 로딩UI를 실행하며 페이드인아웃 기법을 사용하였다.

* #### 오브젝트 위치 파악(시야각 구현)
  - 해당 게임에서는 탱크가 몬스터의 위치를 파악하여 포신을 돌려 대포를 발사한다.(대포는 유도탄과 같이 작동한다.)
  - 지정 원 범위 안의 180도 즉, 정면에 위치한 몬스터를 공격할 수 있게 하였다.
  - Gizmos를 통해 에디터에서 범위를 확인할 수 있게 하였다.

* #### 인벤토리 간의 이동
  - 인벤토리 스크립트와 인벤토리슬롯 스크립트를 두어 따로 관리하였고 스킬을 드래그할 시 드래그한 스킬을 인벤토리 스크립트에서 저장한다.
  - 드래그중인 스킬이 인벤토리 외부에서 드래그가 끝났다면 원래 자리로 돌아오도록 구현하였으며, 다른 인벤토리슬롯에 드랍되었으면
    그 곳에 스킬이 있는지 여부에 따라 교체되거나 이동되는 식으로 구현하였다.
    
* #### 스킬 쿨타임
  - 스킬슬롯에 스킬이 시전되고 있을 경우 다른 스킬을 올리면 교체가 되며 쿨타임이 돌고 있을 경우 위치를 옮겨도 쿨타임은 유지된다.

* #### 파티클 충돌 감지
  - OnParticleCollision과 OnParticleTrigger를 통해 파티클 콜리전하는 방법을 터득하였다.
  - Sub Emitters를 통해 추가 이펙트 하는 방법을 터득하였다. 해당 게임에서는 Snow스킬의 경우 충돌이 발생할 시 폭발 이펙트가 추가로 발생한다.
    
* #### Json 데이터 로드 및 저장
  - 게임 종료 혹은 강제 종료 시에 데이터를 저장하며 게임 시작 시 데이터를 로드하여 반영한다.
  - 모바일에서도 Application.persistentDataPath경로를 통해 동일하게 저장하고 로드하도록 하였다.
    
* #### 시간 보상
  - DateTime을 통해 게임 종료 시 시간을 저장하고 게임 시작 시 시간과 비교하여 오프라인 보상을 주도록 하였다.
  - 시간 조작을 통해 보상을 조정할 경우를 대비해 원래 시간으로 돌릴 때는 그만큼 보상이 차감되도록 하였다.
    

## 게임 화면
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410073-2aaebef8-8da9-4adc-8237-bf0ff9af57b8.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410074-c5152a58-65ac-4892-93e3-9b8fac78f3fd.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410075-6918c3bc-b4d5-463b-a417-195b91f3e0a6.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410076-d29994e6-1559-4722-837f-12dfc4c4a81b.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410077-275a036e-c9db-4faa-9556-d3a04a77c2c5.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410078-817809c5-9a17-463a-be33-b43323b03e6a.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410079-9ee125da-26e7-4e66-baa9-fb52c660487d.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410082-a10096b4-6b95-49e9-b526-3df2c7769358.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410083-19b790ee-9c87-403a-afdf-ec2c47708dcf.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161410085-0144cef4-4ef6-4dab-b920-76e7c4609faa.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161411749-694eb062-25e0-4c4a-ae1b-9b6777e4aadf.png"/>
<img width="80%" src="https://user-images.githubusercontent.com/37278829/161411748-2cd0a110-f670-4570-9ad1-7be1087d09de.png"/>
