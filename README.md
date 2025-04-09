# Exclude Child Bones (for old DynamicBones) - NDMF Plugin (Modular Avatar)

Move child bones other than KeepTransforms to another location, while keeping them follow their original position (using Constraints).

KeepTransforms以外の子ボーンを別の場所に移動し、しかし元の位置に追従するようにする。

Mainly useful for child bones used with legacy DynamicBone.

主に古いDynamicBoneの子ボーンに有効です。

## Install

### VCC用インストーラーunitypackageによる方法（おすすめ）

Download and unzip `net.narazaka.vrchat.exclude-child-bones-installer.zip` from: https://github.com/Narazaka/ExcludeChildBones/releases/latest 
Then import it into your project.

---

https://github.com/Narazaka/ExcludeChildBones/releases/latest から `net.narazaka.vrchat.exclude-child-bones-installer.zip` をダウンロードして解凍し、対象のプロジェクトにインポートする。

### VCCによる方法

1. Go to https://vpm.narazaka.net/ and click "Add to VCC".
2. In VCC settings, confirm "Narazaka VPM Listing" is checked under Installed Repositories.
3. In your project, open "Manage Project" and install "Exclude Child Bones (for old DynamicBones)".

---

1. https://vpm.narazaka.net/ から「Add to VCC」ボタンを押してリポジトリをVCCにインストールします。
2. VCCでSettings→Packages→Installed Repositoriesの一覧中で「Narazaka VPM Listing」にチェックが付いていることを確認します。
3. アバタープロジェクトの「Manage Project」から「Exclude Child Bones (for old DynamicBones)」をインストールします。

## Usage

Attach the `ExcludeChildBones` component to the DynamicBone's parent bone, and specify the child bones to be treated as bones in the `KeepTransforms` field.

DynamicBoneの親ボーンなどにExcludeChildBonesコンポーネントを付けて、ボーンとして扱う子ボーンをKeepTransformsに指定する。

If you want to specify objects within the child bones, set the `MoveTo` property to the parent object of the parent bone.

子ボーン内のオブジェクトを指定したい場合は、MoveToプロパティに親ボーンの親オブジェクトを指定する。

## License

[Zlib License](LICENSE.txt)
