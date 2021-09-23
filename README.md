# SceneLinkedSMB
## 这是什么？
![图片](https://user-images.githubusercontent.com/41114110/134460230-7f05b89b-c848-492c-b2af-d5d3532737b7.png)

对Unity中的动画状态机StateMachineBehaviour的一个扩展。它的好处是：
* 使动画逻辑与Mono行为分离，形成松耦合，可扩展的状态架构。
* 自动链接StateMachineBehaviour和MonoBehaviour,削减GetComponent对于性能的影响。
* 更加自定义的动画控制，创建更复杂的AI。
## 示例说明
1. 示例中有AI有两个动画行为，一个是行走，一个是奔跑。在追踪到达障碍时都会检测前方是否存在障碍。
2. 行走状态下遇到障碍会转向回头。
3. 奔跑状态下遇到障碍会冲破障碍。
4. 可以看到，同样是遇到障碍物，AI因为此时动画状态的不同，表现出了不同的行为。
5. SceneLinkedSMB可以将逻辑分割在动画片段中，将行为分割在MonoBehaviour中，并且可以自动链接，在逻辑层调用行为层。形成可扩展的AI行为架构。
## 如何使用
1. Core文件夹中的SceneLinkedSMB类是核心类，将此类移到你的项目。
2. 创建自己的动画类继承SceneLinkedSMB，并实现你需要的生命周期方法。
3. 将你自己的动画类Add到Animation资源。
4. 在MonoBehaviour中进行初始化链接。
