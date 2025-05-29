# com.peaning39.statmodule
StatModule for Unity

이 스탯 시스템은 단순히 캐릭터와 장비의 수치를 합산하는 구조를 넘어서,  
버프/디버프, 스킬 효과, 상태이상, 환경 요소 등 다양한 외적 요인이 스탯에 영향을 줄 수 있는 구조를  
확장성 있게 관리할 수 있도록 설계되었습니다.

`StatModule`을 중심으로 스탯 변경을 통합적으로 관리하며,  
`UniRx`를 이용하여 `Subject` 기반의 이벤트 알림 구조와 `SetStatLinked` 기반의 구독 모델을 통해  
UI와 시스템이 스탯 변경에 실시간으로 반응할 수 있도록 구성되어 있습니다.

장기적인 게임 시스템 개발을 염두에 두고,  
스탯의 책임 분리, 반응성, 모듈화, 재사용성을 고려하여 설계한 개인 구조화 프로젝트입니다.

---

※ 이 패키지는 [UniRx](https://github.com/neuecc/UniRx) 에 의존합니다.  
설치 경로: https://github.com/neuecc/UniRx/releases/tag/7.1.0
